using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoftTask.Application.Services;
using NadinSoftTask.Core.Dtos.Account;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Interfaces;
using System.Security.Claims;

namespace NadinSoftTask.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        ProductGetDto product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetProducts([FromQuery] ProductFilterDto productFilter)
    {
        List<ProductGetDto> products = await _productService.ListProductsAsync(productFilter);
        return Ok(products);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateProduct(ProductDetailsDto productDetails)
    {
        var userIdDto = new UserIdDto
        (
            UserId: User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new NullReferenceException()
        );

        ProductCreateDto productCreate = _mapper.Map<ProductCreateDto>(productDetails);
        _mapper.Map<UserIdDto, ProductCreateDto>(userIdDto, productCreate);

        int id = await _productService.CreateProductAsync(productCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdate)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (userId != await _productService.GetCreatorId(productUpdate.Id))
            return Unauthorized();

        ProductGetDto updatedProduct = await _productService.UpdateProductAsync(productUpdate);
        
        return Ok(updatedProduct);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId != await _productService.GetCreatorId(id))
            return Unauthorized();

        await _productService.DeleteProductAsync(id);
        return Ok();
    }



}
