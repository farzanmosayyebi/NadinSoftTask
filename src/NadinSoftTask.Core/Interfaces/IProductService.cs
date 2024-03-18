using NadinSoftTask.Core.Dtos.Product;

namespace NadinSoftTask.Core.Interfaces;

public interface IProductService
{
    Task<int> CreateProductAsync(ProductCreate productCreate);
    Task<List<ProductGet>> ListProductsAsync(ProductFilter productFilter);
    Task<ProductGet> GetProductByIdAsync(int id);
    Task<ProductGet> UpdateProductAsync(ProductUpdate productUpdate);
    Task DeleteProductAsync(int id);
}
