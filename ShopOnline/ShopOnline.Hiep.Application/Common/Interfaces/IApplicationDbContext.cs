using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Brands> Brands { get; }
        DbSet<Categories> Categories { get; }
        DbSet<Images> Images { get; }
        DbSet<OrderItems> OrderItems { get; }
        DbSet<Orders> Orders { get; }
        DbSet<Payments> Payments { get; }
        DbSet<Products> Products { get; }
        DbSet<Promotions> Promotions { get; }
        DbSet<Properties> Properties { get; }
        DbSet<Ratings> Ratings { get; }
        DbSet<Statuses> statuses { get; }
        DbSet<Messages> Messages { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
