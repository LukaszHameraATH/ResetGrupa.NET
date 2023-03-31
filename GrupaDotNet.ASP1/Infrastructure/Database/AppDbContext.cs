using GrupaDotNet.ASP1.Model;
using Microsoft.EntityFrameworkCore;

namespace GrupaDotNet.ASP1.Infrastructure.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Bike> Bikes { get; private set; }
    }
}
