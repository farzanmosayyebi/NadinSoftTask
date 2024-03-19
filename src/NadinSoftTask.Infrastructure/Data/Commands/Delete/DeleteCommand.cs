using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Delete;

public class DeleteCommand : IRequest
{
    public Product Entity { get; set; }

    public DeleteCommand(Product entity)
    {
        Entity = entity; 
    }
}
