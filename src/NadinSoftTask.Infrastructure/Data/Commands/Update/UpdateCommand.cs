using MediatR;
using NadinSoftTask.Core.Dtos.Product;
using NadinSoftTask.Core.Models;

namespace NadinSoftTask.Infrastructure.Data.Commands.Update;
public class UpdateCommand : IRequest<Product> 
{
    public ProductUpdateDto EntityUpdateDto { get; set; }

    public UpdateCommand(ProductUpdateDto entityUpdateDto)
    {
        EntityUpdateDto = entityUpdateDto;
    }
}
