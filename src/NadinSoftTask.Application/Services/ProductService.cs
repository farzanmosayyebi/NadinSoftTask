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

    public async Task<int> CreateProductAsync(ProductCreateDto productCreate)
    {
        Product product = _mapper.Map<Product>(productCreate);
        
        var request = new CreateCommand(product);
        return await _mediator.Send(request);
    }

    public async Task<ProductGetDto> GetProductByIdAsync(int id)
    {
        var request = new GetByIdQuery(id);
        Product product = await _mediator.Send(request);
        
        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task<List<ProductGetDto>> ListProductsAsync(ProductFilterDto productFilter)
    {
        var request = new ListEntitiesQuery();
        List<Product> products = await _mediator.Send(request);
       
        return _mapper.Map<List<ProductGetDto>>(products);
    }

    public async Task<ProductGetDto> UpdateProductAsync(ProductUpdateDto productUpdate)
    {
        Product product = _mapper.Map<Product>(productUpdate);

        var request = new UpdateCommand(product);
        Product result = await _mediator.Send(request);
        
        return _mapper.Map<ProductGetDto>(result);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _mediator.Send(new GetByIdQuery(id));

        if (product != null)
            await _mediator.Send(new DeleteCommand(product));
    }
}
