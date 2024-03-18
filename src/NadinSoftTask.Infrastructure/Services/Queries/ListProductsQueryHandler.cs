using Microsoft.EntityFrameworkCore;
using MediatR;
using NadinSoftTask.Infrastructure.Data;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Services.Queries;

public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, List<Product>> 
{
    private readonly ApplicationDbContext _context;

    public ListProductsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(ListProductsQuery query, CancellationToken cancellationToken)
    {
        IQueryable<Product> products = _context.Products.AsQueryable();

        foreach (var filter in query.Filters) 
            products = products.Where(filter);

        foreach (var include in query.Includes)
            products = products.Include(include);

        if (query.Skip != null)
            products = products.Skip(query.Skip.Value);

        if (query.Take != null)
            products = products.Take(query.Take.Value);

        return await products.ToListAsync();

    }
}
