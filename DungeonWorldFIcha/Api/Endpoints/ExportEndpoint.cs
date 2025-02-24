using System.Text.Json;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services;
using DungeonWorldFIcha.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DungeonWorldFIcha.Api.Endpoints;

public static class ExportEndpoint
{
    public static void MapExportApi(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:int}", ExportPerson);


    }

    public static async Task<IResult> ExportPerson(int id, IPersonagemService personagemService)
    {
        Personagem? personagem = null;
        try
        {
            personagem = await personagemService.GetPersonagemById(id);
        }
        catch
        {
            return Results.NotFound("Personagem não encontrado");
        }
        
        return Results.Ok(personagem);
    }


}