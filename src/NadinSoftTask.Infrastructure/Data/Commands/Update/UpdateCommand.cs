using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Update;
public class UpdateCommand<T> : IRequest<T> where T : EntityBase
{
    public T Entity { get; set; }

    public UpdateCommand(T entity)
    {
        Entity = entity;
    }
}
