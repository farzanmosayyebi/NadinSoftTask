using MediatR;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Models;
using System.Linq.Expressions;

namespace NadinSoftTask.Infrastructure.Data.Queries;

public class ListEntitiesQuery : IRequest<List<Product>>
{
    public Expression<Func<Product, bool>>[] Filters { get; set; }
    public int? Skip { get; set; }
    public int? Take { get; set; }
    public Expression<Func<Product, object>>[] Includes { get; set; }

    public ListEntitiesQuery(ProductFilterDto productFilter, params Expression<Func<Product, object>>[] includes)
    {
        Includes = includes ?? Array.Empty<Expression<Func<Product, object>>>();

        Expression<Func<Product, bool>> nameFilter = product => productFilter.Name == null ? true
            : product.Name.StartsWith(productFilter.Name);
     
        Expression<Func<Product, bool>> isAvailable = product => productFilter.IsAvailable == null ? true
            : product.IsAvailable == productFilter.IsAvailable;
        
        Expression<Func<Product, bool>> creatorFilter = product => productFilter.CreatorUserName == null ? true
            : product.Creator.UserName.StartsWith(productFilter.CreatorUserName);

        Filters = new Expression<Func<Product, bool>>[] { nameFilter, isAvailable, creatorFilter};

        Skip = productFilter.Skip;
        Take = productFilter.Take;
    }
}
