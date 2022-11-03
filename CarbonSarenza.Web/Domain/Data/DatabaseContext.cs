using CarbonSarenza.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarbonSarenza.Web.Domain.Data;

public class DatabaseContext : DbContext
{
    
    public DbSet<Setting> Settings { get; set; }
    public DbSet<History> History { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }
}