using Microsoft.EntityFrameworkCore;

namespace NadinSoftTask.Core.Models;

[Index(nameof(ManufacturerEmail), nameof(ProduceDate), IsUnique = true)]
public class Product : EntityBase
{
    public string Name { get; set; } = default!;
    public DateOnly ProduceDate { get; set; }
    public string ManufacturerEmail { get; set; } = default!;
    public string ManufacturerPhone { get; set;} = default!;
    public bool IsAvailable { get; set; }
    public ApplicationUser Creator { get; set; } = default!;
}
