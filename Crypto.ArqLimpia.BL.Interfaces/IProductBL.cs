using Crypto.ArqLimpia.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.ArqLimpia.BL.Interfaces
{
    public interface IProductBL
    {
        Task<CreateProductOutputDTOs> CreateProduct(CreateProductInputDTOs pProducts);
        Task<UpdateProductOutputDTOs> Update(UpdateProductOutputDTOs pProducts);
        Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProducts);
        Task<List<SearchProducOutputDTOs>> Search(SearchProducOutputDTOs pProducts);
        Task<GetByIdProductOutputDTO> GetById(GetByIdProductOutputDTO pProducts);
    }
}
