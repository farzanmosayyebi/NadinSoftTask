using Microsoft.EntityFrameworkCore;
using MediatR;
using NadinSoftTask.Infrastructure.Data;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class ListEntitiesQueryHandler : IRequestHandler<ListEntitiesQuery, List<Product>>
{
    private readonly ApplicationDbContext _context;

    public ListEntitiesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(ListEntitiesQuery query, CancellationToken cancellationToken)
    {
        //IQueryable<Product> entities = _context.Products.AsQueryable();

        //foreach (var filter in query.Filters)
        //    entities = entities.Where(filter);

        //foreach (var include in query.Includes)
        //    entities = entities.Include(include);

        //if (query.Skip != null)
        //    entities = entities.Skip(query.Skip.Value);

        //if (query.Take != null)
        //    entities = entities.Take(query.Take.Value);

        var entities = _context.Products.ToList();
        return entities;
        //return await entities.ToListAsync(cancellationToken: cancellationToken);

    }
}
