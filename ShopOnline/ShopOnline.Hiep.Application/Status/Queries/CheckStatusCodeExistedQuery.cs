using ShopOnline.Hiep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Hiep.Application.Status.Queries
{
    public class CheckStatusCodeExistedQuery : IRequest<bool>
    {
        public string Id { get; set; } = null!;
    }

    internal class CheckAccountGroupCodeExistedQueryHandler : IRequestHandler<CheckStatusCodeExistedQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public CheckAccountGroupCodeExistedQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckStatusCodeExistedQuery request, CancellationToken cancellationToken)
        {
            return await _context.statuses.AsNoTracking().Where(x => x.Id == request.Id).AnyAsync();
        }
    }
}
