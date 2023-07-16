using Crypto.ArqLimpia.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.ArqLimpia.DAL
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<ProductEN> Products { get; set; }
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options) { }

    }
}
