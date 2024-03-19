using MediatR;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class ListEntitiesQuery : IRequest<List<Product>>
{
    public Expression<Func<Product, bool>>[] Filters { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public Expression<Func<Product, object>>[] Includes { get; set; }

    public ListEntitiesQuery(Expression<Func<Product, bool>>[] filters = null!,
            int? skip = null,
            int? take = null,
            params Expression<Func<Product, object>>[] includes)
    {
        Filters = filters ?? Array.Empty<Expression<Func<Product, bool>>>();
        Includes = includes ?? Array.Empty<Expression<Func<Product, object>>>();

        Skip = skip;
        Take = take;
    }
}
