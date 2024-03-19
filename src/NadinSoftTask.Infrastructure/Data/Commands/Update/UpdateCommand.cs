using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Update;
public class UpdateCommand : IRequest<Product> 
{
    public Product Entity { get; set; }

    public UpdateCommand(Product entity)
    {
        Entity = entity;
    }
}
