using AutoMapper;
using MediatR;
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
        Product entity = await _context.Products.FindAsync(command.Entity.Id);

        _mapper.Map<Product, Product>(command.Entity, entity);
        _context.Update(entity);

        await _context.SaveChangesAsync();
        
        return entity;
    }


}
