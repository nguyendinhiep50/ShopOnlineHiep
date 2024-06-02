using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;

namespace ShopOnline.Hiep.Application.Category.Queries
{
    public class CheckCategoryCodeExistedQuery : IRequest<bool>
    {
        public string Id { get; set; } = null!;
    }
    internal class CheckCategoryCodeExistedQueryHandler : IRequestHandler<CheckCategoryCodeExistedQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public CheckCategoryCodeExistedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckCategoryCodeExistedQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking().Where(x => x.Id == request.Id).AnyAsync();
        }
    }
}
