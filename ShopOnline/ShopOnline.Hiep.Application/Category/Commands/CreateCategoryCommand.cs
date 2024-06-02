using AutoMapper;
using MediatR;
using ShopOnline.Hiep.Application.Category.Dtos;
using ShopOnline.Hiep.Application.Category.Queries;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Category.Commands
{
    public class CreateCategoryCommand : IRequest<ResponseModel<bool>>
    {
        public CategoryAddDto Dto { get; set; } = null!;
    }
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCategoryCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Categories>(request.Dto!);

            var existedCategoryCode = await _mediator.Send(new CheckCategoryCodeExistedQuery
            {
                Id = rating.Id!
            });

            if (existedCategoryCode)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Category với mã {rating.Id} đã tồn tại"
                };
            }

            await _context.Categories.AddAsync(rating);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }

}
