using Microsoft.AspNetCore.Identity;

namespace NadinSoftTask.Core.Models;

public class ApplicationUser : IdentityUser
{
    public List<Product> CreatedProducts { get; set; } = default!;
}
