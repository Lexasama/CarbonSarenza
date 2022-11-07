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

    protected  override void  OnModelCreating(ModelBuilder model )
    {
        base.OnModelCreating(model);
        model.Entity<Setting>().HasData(new Setting()
        {
            Id = 1,
            ColdTemperature = 22,
            HotTemperature = 40
        });

        model.Entity<History>().HasData(new History()
        {
            Id = 1,
            TemperatureC = 22
        });

    }
}