using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Create;

public class CreateCommand : IRequest<int>
{
    public Product Entity { get; set; }
    public CreateCommand(Product entity)
    {
        Entity = entity;
    }
}
