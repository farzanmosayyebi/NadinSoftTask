using MediatR;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Delete;

public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>> where T : EntityBase
{
    private readonly ApplicationDbContext _context;

    public DeleteCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCommand<T> command, CancellationToken cancellationToken)
    {
        _context.Set<T>().Remove(command.Entity);

        await _context.SaveChangesAsync();
    }
}
