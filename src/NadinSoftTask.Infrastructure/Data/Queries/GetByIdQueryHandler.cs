using MediatR;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Infrastructure.Data;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class GetByIdQueryHandler<T> : IRequestHandler<GetByIdQuery<T>, T> where T : EntityBase
{
    private readonly ApplicationDbContext _context;

    public GetByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T?> Handle(GetByIdQuery<T> query, CancellationToken cancellationToken)
    {
        IQueryable<T> result = _context.Set<T>().AsQueryable();

        result = result.Where(e => e.Id == e.Id);

        foreach (var include in query.Includes)
            result = result.Include(include);

        return await result.SingleOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
