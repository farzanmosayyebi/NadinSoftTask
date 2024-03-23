using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Core.Exceptions;
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
        Product entityToUpdate = await _context.Products.FindAsync(command.EntityUpdateDto.Id)
            ?? throw new ItemNotFoundException(command.EntityUpdateDto.Id, typeof(Product).Name);

        _mapper.Map(command.EntityUpdateDto, entityToUpdate);

        await _context.SaveChangesAsync(cancellationToken);

        return entityToUpdate;
    }


}
