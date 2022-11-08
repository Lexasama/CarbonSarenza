using Microsoft.EntityFrameworkCore;
using Sarenza.Core.Entities;

namespace Sarenza.DAL.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Setting> Settings { get; set; }
    public DbSet<History> History { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        model.Entity<Setting>().HasKey(s => s.Id);
        model.Entity<Setting>().HasData(new Setting()
        {
            Id = 1,
            ColdTemperature = 22,
            HotTemperature = 40,
            CreationDateTime = DateTime.UtcNow
        });

        model.Entity<History>().HasKey(h => h.Id);
        model.Entity<History>().HasData(new History()
        {
            Id = 1,
            TemperatureC = 22,
            Date = DateTime.UtcNow
        });
    }
}