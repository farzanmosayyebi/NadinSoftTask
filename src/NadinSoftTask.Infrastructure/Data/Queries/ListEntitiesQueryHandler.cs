using Microsoft.EntityFrameworkCore;
using MediatR;
using NadinSoftTask.Infrastructure.Data;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class ListEntitiesQueryHandler<T> : IRequestHandler<ListEntitiesQuery<T>, List<T>> where T : EntityBase
{
    private readonly ApplicationDbContext _context;

    public ListEntitiesQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> Handle(ListEntitiesQuery<T> query, CancellationToken cancellationToken)
    {
        IQueryable<T> entities = _context.Set<T>().AsQueryable();

        foreach (var filter in query.Filters)
            entities = entities.Where(filter);

        foreach (var include in query.Includes)
            entities = entities.Include(include);

        if (query.Skip != null)
            entities = entities.Skip(query.Skip.Value);

        if (query.Take != null)
            entities = entities.Take(query.Take.Value);

        return await entities.ToListAsync();

    }
}
