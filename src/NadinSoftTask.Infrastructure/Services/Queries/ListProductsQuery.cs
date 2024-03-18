using MediatR;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Services.Queries;

public class ListProductsQuery : IRequest<List<Product>>
{
    public Expression<Func<Product, bool>>[] Filters { get; set; } = default!;
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public Expression<Func<Product, object>>[] Includes { get; set; } = default!;

    public ListProductsQuery(Expression<Func<Product, bool>>[] filters = null!,
            int? skip = null,
            int? take = null,
            params Expression<Func<Product, object>>[] includes)
    {
        if (filters != null)
            Filters = filters;
        if (skip != null)
            Skip = skip;
        if (take != null)
            Take = take;
        if (includes != null) 
            Includes = includes;
    }
}
