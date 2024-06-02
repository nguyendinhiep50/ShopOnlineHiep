using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;

namespace ShopOnline.Hiep.Application.Brand.Queries
{
    public class CheckBrandCodeExistedQuery : IRequest<bool>
    {
        public string Id { get; set; } = null!;
    }

    internal class CheckBrandCodeExistedQueryHandler : IRequestHandler<CheckBrandCodeExistedQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public CheckBrandCodeExistedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckBrandCodeExistedQuery request, CancellationToken cancellationToken)
        {
            return await _context.Brands.AsNoTracking().Where(x => x.Id == request.Id).AnyAsync();
        }
    }

}
