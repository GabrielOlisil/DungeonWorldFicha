using DungeonWorldFIcha;
using DungeonWorldFIcha.Components;
using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Hubs;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);



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


var app = builder.Build();

app.ApplyPendingMigrations();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapHub<PersonagemHub>("/personagemHub");
app.MapHub<DadosHub>("/dadosHub");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();