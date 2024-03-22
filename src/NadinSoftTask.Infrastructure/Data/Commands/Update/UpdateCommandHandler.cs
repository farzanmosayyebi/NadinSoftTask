using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Update;

public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Product> 
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UpdateCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Product> Handle(UpdateCommand command, CancellationToken cancellationToken)
    {
        //_context.Update(command.Entity);

        if (_context.Entry(command.Entity).State == EntityState.Detached)
            _context.Attach(command.Entity);

        _context.Entry(command.Entity).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);
        
        return command.Entity;
    }


}
