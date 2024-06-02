using AutoMapper;
using MediatR;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Rating.Dtos;
using ShopOnline.Hiep.Application.Rating.Queries;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Rating.Commands
{
    public class CreateRatingCommand : IRequest<ResponseModel<bool>>
    {
        public RatingAddDto Dto { get; set; } = null!;
    }

    internal class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateRatingCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel<bool>> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = _mapper.Map<Ratings>(request.Dto!);

            var existedRatingCode = await _mediator.Send(new CheckRatingCodeExistedQuery
            {
                Id = rating.Id!
            });

            if (existedRatingCode)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Rating với mã {rating.Id} đã tồn tại"
                };
            }

            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
