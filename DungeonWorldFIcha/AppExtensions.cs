using System.Text.Json;
using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Services;
using DungeonWorldFIcha.Services.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace DungeonWorldFIcha;

public static class AppExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRollService, RollCountService>();
        services.AddSingleton<IMarkdownService,MarkdownService>();
        services.AddScoped<IPersonagemService, PersonagemService>();
    }

    public static void ConfigureBuilder(this IHostApplicationBuilder builder)
    {
        if (!builder.Environment.IsDevelopment())
        {
            const string keysPath = "/var/protection-keys";
            if (!Directory.Exists(keysPath))
            {
                Directory.CreateDirectory(keysPath);
            }

            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
                .SetApplicationName("BlazorApp");
        }

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddDbContext<DungeonWorldContext>();

        builder.Services.AddApplicationServices();
        

        builder.Services.AddSignalR();
    }

    public static void ApplyPendingMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<DungeonWorldContext>();

        var pendingMigrations = dbContext.Database.GetPendingMigrations();
        if (!pendingMigrations.Any()) return;

        dbContext.Database.Migrate();
    }
}