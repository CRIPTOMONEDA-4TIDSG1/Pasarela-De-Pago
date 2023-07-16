using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.ArqLimpia.EN.Interfaces
{
    public interface IProduct
    {
        void Create(ProductEN pProducts);
        void Update(ProductEN pProducts);
        void Delete(ProductEN pProducts);
        Task<ProductEN> GetById(ProductEN pUser);

        Task<List<ProductEN>> Search(ProductEN pUser);
        Task<ProductEN> GetById(int id);
    }
}
