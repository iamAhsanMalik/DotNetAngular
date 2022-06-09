using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  public DbSet<TblEmployee> Employees { get; set; } = default!;
  public DbSet<TblDesignation> Designations { get; set; } = default!;
}
