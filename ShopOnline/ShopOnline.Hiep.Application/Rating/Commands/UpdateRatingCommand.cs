using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Rating.Dtos;

namespace ShopOnline.Hiep.Application.Rating.Commands
{
    public class UpdateRatingCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
        public RatingUpdateDto Dto { get; set; } = null!;
    }

    internal class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRatingCommandHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<bool>> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var ratingCode = request.Id ?? string.Empty;
            var rating = await _context.Ratings.FirstOrDefaultAsync(x => x.Id == ratingCode);

            if (rating == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Tài khoản với mã {ratingCode} không tồn tại"
                };
            }

            _mapper.Map(request.Dto, rating);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
