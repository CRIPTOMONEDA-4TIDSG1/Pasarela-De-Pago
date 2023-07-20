using Crypto.ArqLimpia.EN;
using Microsoft.EntityFrameworkCore;


namespace Crypto.ArqLimpia.DAL
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<ProductEN> Products { get; set; }
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options) { }

    }
}
