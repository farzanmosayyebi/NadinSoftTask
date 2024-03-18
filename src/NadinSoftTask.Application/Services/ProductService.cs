using MediatR;
using AutoMapper;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Infrastructure.Data.Commands.Create;
using NadinSoftTask.Infrastructure.Data.Queries;
using NadinSoftTask.Core.Interfaces;
using NadinSoftTask.Infrastructure.Data.Commands.Update;
using NadinSoftTask.Infrastructure.Data.Commands.Delete;

namespace NadinSoftTask.Application.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<int> CreateProductAsync(ProductCreate productCreate)
    {
        Product product = _mapper.Map<Product>(productCreate);
        
        var request = new CreateCommand<Product>(product);
        return await _mediator.Send(request);
    }

    public async Task<ProductGet> GetProductByIdAsync(int id)
    {
        var request = new GetByIdQuery<Product>(id);
        Product product = await _mediator.Send(request);
        
        return _mapper.Map<ProductGet>(product);
    }

    public async Task<List<ProductGet>> ListProductsAsync(ProductFilter productFilter)
    {
        var request = new ListEntitiesQuery<Product>();
        List<Product> products = await _mediator.Send(request);
       
        return _mapper.Map<List<ProductGet>>(products);
    }

    public async Task<ProductGet> UpdateProductAsync(ProductUpdate productUpdate)
    {
        Product product = _mapper.Map<Product>(productUpdate);

        var request = new UpdateCommand<Product>(product);
        Product result = await _mediator.Send(request);
        
        return _mapper.Map<ProductGet>(result);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _mediator.Send(new GetByIdQuery<Product>(id));

        if (product != null)
            await _mediator.Send(new DeleteCommand<Product>(product));
    }
}
