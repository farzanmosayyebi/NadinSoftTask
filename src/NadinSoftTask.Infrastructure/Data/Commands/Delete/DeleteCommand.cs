using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Delete;

public class DeleteCommand<T> : IRequest where T : EntityBase
{
    public T Entity { get; set; }

    public DeleteCommand(T entity)
    {
        Entity = entity; 
    }
}
