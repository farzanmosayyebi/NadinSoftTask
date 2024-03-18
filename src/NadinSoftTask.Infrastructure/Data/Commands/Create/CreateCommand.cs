using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Create;

public class CreateCommand<T> : IRequest<int> where T : EntityBase
{
    public T Entity { get; set; }
    public CreateCommand(T entity)
    {
        Entity = entity;
    }
}
