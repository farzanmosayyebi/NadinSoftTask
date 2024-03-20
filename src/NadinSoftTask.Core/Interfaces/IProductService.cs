using NadinSoftTask.Core.Dtos.Product;

namespace NadinSoftTask.Core.Interfaces;

public interface IProductService
{
    Task<int> CreateProductAsync(ProductCreateDto productCreate);
    Task<List<ProductGetDto>> ListProductsAsync(ProductFilterDto productFilter);
    Task<ProductGetDto> GetProductByIdAsync(int id);
    Task<ProductGetDto> UpdateProductAsync(ProductUpdateDto productUpdate);
    Task DeleteProductAsync(int id);
}
