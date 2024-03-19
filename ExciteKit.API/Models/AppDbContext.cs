using Microsoft.EntityFrameworkCore;

namespace ExciteKit.API.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<DataEvent> Events { get; set; } = null!;
    public DbSet<UserSteps> UserSteps { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<UserSteps>().HasNoKey().ToView(null);
    }
}