using AutoMapper;
using MediatR;
using ShopOnline.Hiep.Application.Brand.Dtos;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Brand.Queries;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Brand.Commands
{
    public class CreateBrandCommand : IRequest<ResponseModel<bool>>
    {
        public BrandAddDto Dto { get; set; } = null!;
    }
    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateBrandCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel<bool>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Brands>(request.Dto!);

            var existedBrandCode = await _mediator.Send(new CheckBrandCodeExistedQuery
            {
                Id = rating.Id!
            });

            if (existedBrandCode)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Brand với mã {rating.Id} đã tồn tại"
                };
            }

            await _context.Brands.AddAsync(rating);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }

}
