using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
  public class HairSalonContext : DbContext
  {
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Stylists> Stylists { get; set; }

    public HairSalonContext(DbContextOptions options) : base(options) { }
  }
}