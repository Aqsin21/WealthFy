using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthFy.Infrastructure.Persistence
{
    public class WealthFyDbContextFactory : IDesignTimeDbContextFactory<WealthFyDbContext>
    {
        public WealthFyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WealthFyDbContext>();

            // Development connection string
            optionsBuilder.UseSqlServer("Server=DESKTOP-L886DE2;Database=WealthFy;Trusted_Connection=True;TrustServerCertificate=True");

            return new WealthFyDbContext(optionsBuilder.Options);
        }
    }
}
