using System.Text.Json;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services;
using DungeonWorldFIcha.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DungeonWorldFIcha.Api.Endpoints;

public static class ExportEndpoint
{
    public static void MapApi(this RouteGroupBuilder group)
    {
        group.MapGet("/exports/{id:int}", ExportPerson);
        group.MapGet("/deleteperson/{id:int}", DeletePerson);

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
    
    public static async Task<IResult> DeletePerson(int id, IPersonagemService personagemService)
    {
        try
        {
            if (!await personagemService.RemovePersonageById(id))
                return Results.BadRequest("Personagem não encontrado");

        }
        catch
        {
            return Results.NotFound("Personagem não encontrado");
        }
        
        return Results.Ok("personagem deletado");
    }


}