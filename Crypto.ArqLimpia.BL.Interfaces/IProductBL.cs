using Crypto.ArqLimpia.BL.DTOs;



namespace Crypto.ArqLimpia.BL.Interfaces
{
    public interface IProductBL
    {
        Task<CreateProductOutputDTOs> Create(CreateProductInputDTOs pProducts);
        Task<UpdateProductOutputDTOs> Update(UpdateProductInputDTOs pProducts);
        Task<DeleteProductsOutputDTOs> Delete(DeleteProductsInputDTOs pProducts);
        Task<List<getProductsOutputDTOs>> Search(getProductsInputDTOs pProducts);
        Task<GetByIdProductOutputDTO> GetById(int id);
    }
}
