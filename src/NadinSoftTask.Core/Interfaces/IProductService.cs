using NadinSoftTask.Core.Dtos.Product;

namespace NadinSoftTask.Core.Interfaces;

public interface IProductService
{
    Task<int> CreateProductAsync(ProductCreate productCreate);
    Task<List<ProductGet>> ListProductsAsync(ProductFilter productFilter);
    Task<ProductGet> GetByIdAsync(int id);
    Task UpdateAsync(ProductUpdate productUpdate);
    Task DeleteAsync(int id);
}
