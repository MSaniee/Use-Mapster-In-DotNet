using MapsterInDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace MapsterInDotNet.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
}

