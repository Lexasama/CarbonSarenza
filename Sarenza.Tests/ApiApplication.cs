using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Storage;
using Sarenza.DAL.Data;

namespace Sarenza.Tests;

internal class ApiApplication : WebApplicationFactory<Program>
{
    private readonly string _env;

    public ApiApplication(string env = "Development")
    {
        _env = env;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_env);
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<DatabaseContext>));

            services.AddDbContext<DatabaseContext>(options =>
                options.UseInMemoryDatabase("Test", new InMemoryDatabaseRoot())
            );

            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            db.Database.EnsureCreated();
            db.SaveChanges();
        });
        return base.CreateHost(builder);
    }

    public static HttpClient CreateClient()
    {
        return new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<DatabaseContext>));
                    services.AddDbContext<DatabaseContext>(options =>
                        options.UseInMemoryDatabase("Test"));
                    var sp = services.BuildServiceProvider();
                    using var scope = sp.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                    db.Database.EnsureCreated();

                    db.SaveChanges();
                });
            }).CreateClient();
    }
}