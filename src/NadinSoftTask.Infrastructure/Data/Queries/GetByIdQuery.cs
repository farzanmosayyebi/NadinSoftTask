using MediatR;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class GetByIdQuery<T> : IRequest<T> where T : EntityBase
{
    public int Id { get; set; }
    public Expression<Func<T, object>>[] Includes { get; set; }
    public GetByIdQuery(int id, params Expression<Func<T, object>>[] includes)
    {
        Id = id;
        Includes = includes ?? Array.Empty<Expression<Func<T, object>>>();
    }
}
