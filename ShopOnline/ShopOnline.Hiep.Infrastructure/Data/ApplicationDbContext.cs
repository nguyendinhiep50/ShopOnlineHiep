using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Domain.Entities;
using ShopOnline.Hiep.Infrastructure.Configurations;

namespace ShopOnline.Hiep.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Categories> Categories => Set<Categories>();
        public DbSet<Brands> Brands => Set<Brands>();
        public DbSet<Ratings> Ratings => Set<Ratings>();
        public DbSet<Images> Images => Set<Images>();
        public DbSet<OrderItems> OrderItems => Set<OrderItems>();
        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<Payments> Payments => Set<Payments>();
        public DbSet<Products> Products => Set<Products>();
        public DbSet<Promotions> Promotions => Set<Promotions>();
        public DbSet<Properties> Properties => Set<Properties>();
        public DbSet<Statuses> statuses => Set<Statuses>();
        public DbSet<Messages> Messages => Set<Messages>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
