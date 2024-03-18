using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Infrastructure.Data;

namespace NadinSoftTask.Infrastructure.Services.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        IQueryable<Product> result = _context.Products.AsQueryable();

        result = result.Where(p => p.Id == query.Id);
        foreach (var include in  query.Includes) 
            result = result.Include(include);

        return await result.SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
