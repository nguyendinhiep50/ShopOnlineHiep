using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;

namespace ShopOnline.Hiep.Application.Rating.Queries
{
    public class CheckRatingCodeExistedQuery : IRequest<bool>
    {
        public string Id { get; set; } = null!;
    }

    internal class CheckRatingCodeExistedQueryHandler : IRequestHandler<CheckRatingCodeExistedQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public CheckRatingCodeExistedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckRatingCodeExistedQuery request, CancellationToken cancellationToken)
        {
            return await _context.Ratings.AsNoTracking().Where(x => x.Id == request.Id).AnyAsync();
        }
    }
}
