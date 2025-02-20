using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Services;
using Microsoft.EntityFrameworkCore;

namespace DungeonWorldFIcha;

public static class AppExtensions
{

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<RollCountService>();
        services.AddSingleton<MarkdownService>();
        services.AddScoped<PersonagemService>();
    }

    public static void ApplyPendingMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var dbContext = serviceScope.ServiceProvider.GetRequiredService<DungeonWorldContext>();

        var pendingMigrations = dbContext.Database.GetPendingMigrations();
        if(!pendingMigrations.Any()) return;
        
        dbContext.Database.Migrate();
    }
    
}