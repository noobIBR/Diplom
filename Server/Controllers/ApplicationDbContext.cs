using Microsoft.EntityFrameworkCore;
using Server.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Audience> Audience { get; set; }
}
