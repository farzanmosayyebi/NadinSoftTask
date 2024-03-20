using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Core.Models;
using System.Security.Claims;

namespace NadinSoftTask.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IProductService _productService;

    public ProductController(IProductService productService, UserManager<ApplicationUser> userManager)
    {
        _productService = productService;
        _userManager = userManager;
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        ProductGetDto product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetProducts([FromQuery] ProductFilterDto productFilter)
    {
        List<ProductGetDto> products = await _productService.ListProductsAsync(productFilter);
        return Ok(products);
    }

    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateProduct(ProductCreateDto productCreate)
    {
        int id = await _productService.CreateProductAsync(productCreate);
        return Ok(id);
    }

    [Authorize]
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdate)
    {
        ProductGetDto updatedProduct = await _productService.UpdateProductAsync(productUpdate);
        return Ok(updatedProduct);
    }

    [Authorize]
    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProductAsync(id);
        return Ok();
    }



}
