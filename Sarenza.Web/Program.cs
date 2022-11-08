using Microsoft.EntityFrameworkCore;
using Sarenza.Core.Repositories;
using Sarenza.Core.Repositories.Base;
using Sarenza.Core.Services;
using Sarenza.DAL.Data;
using Sarenza.DAL.Repositories;
using Sarenza.DAL.Repositories.Base;
using Sarenza.DAL.Services;
using Sarenza.DAL.TemperatureCaptor;

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
builder.Services.AddSingleton<ITemperatureCaptor, TemperatureCaptor>();
builder.Services.AddScoped<ITemperatureHistoryRepository, TemperatureHistoryRepository>();
builder.Services.AddScoped<ISettingRepository, SettingHistoryRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


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

public partial class Program
{
}