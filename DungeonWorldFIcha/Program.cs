using DungeonWorldFIcha.Components;
using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Hubs;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MarkdownService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

builder.Services.AddDbContext<DungeonWorldContext>();
builder.Services.AddSingleton<RollCountService>();
builder.Services.AddScoped<PersonagemService>();

var app = builder.Build();

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