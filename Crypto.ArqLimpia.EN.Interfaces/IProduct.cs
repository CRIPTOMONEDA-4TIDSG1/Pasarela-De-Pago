using Crypto.ArqLimpia.BL.DTOs;

namespace Crypto.ArqLimpia.EN.Interfaces
{
    public interface IProduct
    {
        void Create(ProductEN pProducts);
        void Update(ProductEN pProducts);
        void Delete(ProductEN pProducts);
        Task<ProductEN> GetById(ProductEN pUser);

        Task<List<ProductEN>> Search(getProductsInputDTOs pUser);
        Task<ProductEN> GetById(int id);
    }
}
