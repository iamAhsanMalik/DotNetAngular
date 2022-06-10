using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  public DbSet<Employee> Employees { get; set; } = default!;
  public DbSet<Designation> Designations { get; set; } = default!;
}
