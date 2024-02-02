using Crypto.ArqLimpia.EN;
using Microsoft.EntityFrameworkCore;


namespace Crypto.ArqLimpia.DAL
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<ProductEN> Cryptocurrencies { get; set; }
        public DbSet<OrderEN> CryptoOrder { get ; set;}

        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        modelBuilder.Entity<ProductEN>()
            .Property(p => p.price)
            .HasColumnType("decimal(18, 2)"); // Especifica la precisión y la escala de la columna price
        
   
        }
        
    }
}
