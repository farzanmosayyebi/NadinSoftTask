using MediatR;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Services.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
    public Expression<Func<Product, object>>[] Includes { get; set; } = default!;
    public GetProductByIdQuery(int id, params Expression<Func<Product, object>>[] includes)
    {
        Id = id;
        if (includes != null)
        Includes = includes;
    }
}
