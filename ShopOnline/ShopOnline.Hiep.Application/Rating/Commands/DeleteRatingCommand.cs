using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;

namespace ShopOnline.Hiep.Application.Rating.Commands
{
    public class DeleteRatingCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
    }

    internal class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRatingCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (rating == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Rating với mã  {request.Id} không tồn tại"
                };
            }

            rating.Status = true;

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
