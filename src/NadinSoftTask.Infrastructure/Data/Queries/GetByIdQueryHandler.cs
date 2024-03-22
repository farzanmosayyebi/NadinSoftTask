using MediatR;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Infrastructure.Data;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Product> 
{
    private readonly ApplicationDbContext _context;

    public GetByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        IQueryable<Product> result = _context.Products.AsQueryable();

        result = result.Where(e => e.Id == query.Id);

        foreach (var include in query.Includes)
            result = result.Include(include);

        return await result.SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
