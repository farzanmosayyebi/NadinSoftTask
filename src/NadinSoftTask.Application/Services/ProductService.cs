using Microsoft.AspNetCore.Identity;
using MediatR;
using AutoMapper;

using NadinSoftTask.Core.Models;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Infrastructure.Data.Queries;
using NadinSoftTask.Infrastructure.Data.Commands.Create;
using NadinSoftTask.Infrastructure.Data.Commands.Update;
using NadinSoftTask.Infrastructure.Data.Commands.Delete;

namespace NadinSoftTask.Application.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProductService(IMediator mediator, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _mediator = mediator;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<int> CreateProductAsync(ProductCreateDto productCreate)
    {
        ApplicationUser creator = await _userManager.FindByIdAsync(productCreate.CreatorId)
                ?? throw new NullReferenceException();

        Product product = _mapper.Map<Product>(productCreate);
        
        product.Creator = creator;
        
        var request = new CreateCommand(product);
        return await _mediator.Send(request);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(int id)
    {
        var request = new GetByIdQuery(id, product => product.Creator);
        Product product = await _mediator.Send(request)
            ?? throw new NullReferenceException();
        
        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task<List<ProductGetDto>> ListProductsAsync(ProductFilterDto productFilter)
    {
        var request = new ListEntitiesQuery(productFilter, product => product.Creator);
        List<Product> products = await _mediator.Send(request);
       
        return _mapper.Map<List<ProductGetDto>>(products);
    }

    public async Task<ProductGetDto> UpdateProductAsync(ProductUpdateDto productUpdate)
    {
        Product existingProduct = await _mediator.Send(new GetByIdQuery(productUpdate.Id))
            ?? throw new NullReferenceException();

        Product product = _mapper.Map<Product>(productUpdate);

        _mapper.Map<Product, Product>(product, existingProduct);

        var request = new UpdateCommand(product);
        Product result = await _mediator.Send(request);
        
        return _mapper.Map<ProductGetDto>(result);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _mediator.Send(new GetByIdQuery(id))
            ?? throw new NullReferenceException();

        await _mediator.Send(new DeleteCommand(product));
    }

    public async Task<string> GetCreatorId(int productId)
    {
        var product = await _mediator.Send(new GetByIdQuery(productId, product => product.Creator))
            ?? throw new NullReferenceException();
        return product.Creator.Id.ToString();
    }
}
