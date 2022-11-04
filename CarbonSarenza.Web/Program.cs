using CarbonSarenza.Web.Domain.Data;
using CarbonSarenza.Web.Domain.Repositories;
using CarbonSarenza.Web.Domain.Repositories.Base;
using CarbonSarenza.Web.Domain.Services;
using CarbonSarenza.Web.Infrastructure.Repositories;
using CarbonSarenza.Web.Infrastructure.Repositories.Base;
using CarbonSarenza.Web.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddOptions();
builder.Services.AddCors();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("SarenzaDb")
    ));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ITemperatureHistoryRepository, TemperatureHistoryRepository>();
builder.Services.AddTransient<ISettingRepository, SettingHistoryRepository>();
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await dataContext.Database.MigrateAsync();
    await dataContext.History.AddAsync(new CarbonSarenza.Web.Domain.Entities.History() { Date  = DateTime.Now,
        Temperature = 25
    });
    await dataContext.SaveChangesAsync();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
