using MediatR;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class ListEntitiesQuery<T> : IRequest<List<T>> where T : EntityBase
{
    public Expression<Func<T, bool>>[] Filters { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public Expression<Func<T, object>>[] Includes { get; set; }

    public ListEntitiesQuery(Expression<Func<T, bool>>[] filters = null!,
            int? skip = null,
            int? take = null,
            params Expression<Func<T, object>>[] includes)
    {
        Filters = filters ?? Array.Empty<Expression<Func<T, bool>>>();
        Includes = includes ?? Array.Empty<Expression<Func<T, object>>>();

        Skip = skip;
        Take = take;
    }
}
