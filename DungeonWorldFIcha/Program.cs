using DungeonWorldFIcha;
using DungeonWorldFIcha.Components;
using DungeonWorldFIcha.Hubs;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services.Interfaces;
using DungeonWorldFIcha.Api.Endpoints;



var builder = WebApplication.CreateBuilder(args);


builder.ConfigureBuilder();


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

app.MapGroup("/api/exports").MapExportApi();


app.Run();