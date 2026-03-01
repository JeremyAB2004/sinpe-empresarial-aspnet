
using Microsoft.EntityFrameworkCore;
namespace sinpe_empresarial_aspnet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
         public DbSet<Models.Comercios> Comercios { get; set; }
    }
}
