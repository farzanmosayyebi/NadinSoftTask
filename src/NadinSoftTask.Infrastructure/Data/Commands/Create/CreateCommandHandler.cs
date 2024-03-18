using MediatR;
using NadinSoftTask.Core.Models;
using NadinSoftTask.Infrastructure.Data;

namespace NadinSoftTask.Infrastructure.Data.Commands.Create;

public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, int> where T : EntityBase
{
    private readonly ApplicationDbContext _context;

    public CreateCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCommand<T> command, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(command.Entity);
        await _context.SaveChangesAsync();

        return command.Entity.Id;
    }
}
