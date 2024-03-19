using MediatR;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class GetByIdQuery : IRequest<Product> 
{
    public int Id { get; set; }
    public Expression<Func<Product, object>>[] Includes { get; set; }
    public GetByIdQuery(int id, params Expression<Func<Product, object>>[] includes)
    {
        Id = id;
        Includes = includes ?? Array.Empty<Expression<Func<Product, object>>>();
    }
}
