using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NadinSoftTask.Core.Models;

[Index(nameof(UserName), IsUnique = true)]
public class ApplicationUser : IdentityUser<Guid>
{
    [ProtectedPersonalData]
    public new string UserName { get; set; } = default!;
    public List<Product> CreatedProducts { get; set; } = default!;
}
