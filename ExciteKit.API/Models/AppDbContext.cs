using Microsoft.EntityFrameworkCore;

namespace ExciteKit.API.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<DataEvent> Events { get; set; } = null!;
}