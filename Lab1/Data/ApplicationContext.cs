using Lab1.Entities.Hamburgers;
using Lab1.Entities.Recipes;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.Migrate();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(Configuration.ConnectionString);
    }
    public DbSet<Hamburger>? Hamburger { get; set; }
    public DbSet<Recipe>? Recipe { get; set; }
    
}