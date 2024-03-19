using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NadinSoftTask.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ProductCatalogue;Integrated Security=True;";
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(connectionString, opt => opt.UseDateOnlyTimeOnly());

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
