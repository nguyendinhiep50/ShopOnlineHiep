using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Categories> Categories { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
