using AutoMapper;
using MediatR;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Update;

public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommand<T>, T> where T : EntityBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UpdateCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<T> Handle(UpdateCommand<T> command, CancellationToken cancellationToken)
    {
        T entity = await _context.Set<T>().FindAsync(command.Entity.Id);

        _mapper.Map<T, T>(command.Entity, entity);
        _context.Update(entity);

        await _context.SaveChangesAsync();
        
        return entity;
    }


}
