using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WealthFy.Domain.Entities;
using WealthFy.Infrastructure.Identity;

namespace WealthFy.Infrastructure.Persistence
{
    public class WealthFyDbContext:IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public WealthFyDbContext(DbContextOptions<WealthFyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        public DbSet<Investment> Investments => Set<Investment>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Portfolio → User
            builder.Entity<Portfolio>()
                   .HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Portfolio → Investments
            builder.Entity<Portfolio>()
                   .HasMany(p => p.Investments)
                   .WithOne(i => i.Portfolio)
                   .HasForeignKey(i => i.PortfolioId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Investment → Asset
            builder.Entity<Investment>()
                   .HasOne(i => i.Asset)
                   .WithMany()
                   .HasForeignKey(i => i.AssetId)
                   .OnDelete(DeleteBehavior.Restrict);

           
            builder.Entity<Asset>()
                   .HasIndex(a => a.Symbol)
                   .IsUnique();

           
            builder.Entity<Asset>()
                   .Property(a => a.Symbol)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Entity<Asset>()
                   .Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Entity<Portfolio>()
                   .Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }

}
