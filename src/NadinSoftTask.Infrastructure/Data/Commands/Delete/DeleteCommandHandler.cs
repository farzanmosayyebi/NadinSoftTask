using MediatR;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Delete;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand> 
{
    private readonly ApplicationDbContext _context;

    public DeleteCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCommand command, CancellationToken cancellationToken)
    {
        _context.Products.Remove(command.Entity);

        await _context.SaveChangesAsync();
    }
}
