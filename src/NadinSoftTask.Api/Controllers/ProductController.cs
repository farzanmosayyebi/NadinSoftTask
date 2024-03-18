using Microsoft.AspNetCore.Mvc;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Interfaces;

namespace NadinSoftTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        ProductGet product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetProducts(ProductFilter productFilter)
    {
        List<ProductGet> products = await _productService.ListProductsAsync(productFilter);
        return Ok(products);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateProduct(ProductCreate productCreate)
    {
        int id = await _productService.CreateProductAsync(productCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateProduct(ProductUpdate productUpdate)
    {
        ProductGet updatedProduct = await _productService.UpdateProductAsync(productUpdate);
        return Ok(updatedProduct);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }



}
