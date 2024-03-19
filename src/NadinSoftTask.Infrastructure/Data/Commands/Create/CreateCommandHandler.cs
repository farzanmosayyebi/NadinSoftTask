using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, int>
{
    private readonly ApplicationDbContext _context;

    public CreateCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(command.Entity);
        await _context.SaveChangesAsync();

        return command.Entity.Id;
    }
}
