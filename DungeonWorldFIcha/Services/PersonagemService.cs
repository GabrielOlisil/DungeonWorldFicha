using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Hubs;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DungeonWorldFIcha.Services;

public class PersonagemService(DungeonWorldContext context, IHubContext<PersonagemHub> personagemHub)
    : IPersonagemService
{
    public async Task<List<Personagem>> GetPersonagens()
    {
        List<Personagem>? list;
        list = await context.Personagens.AsNoTracking().Include(p => p.Habilidade).ToListAsync();
        return list;
    }

    public async Task<bool> AdicionarPersonagem(Personagem personagem)
    {
        context.Personagens.Add(personagem);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task AtualizarPersonagem(Personagem personagem)
    {
        try
        {
            context.Personagens.Update(personagem);


            if (await context.SaveChangesAsync() > 0)
            {
                context.Entry(personagem).State = EntityState.Detached;

                context.Entry(personagem.Habilidade).State = EntityState.Detached;

                await personagemHub.Clients.All.SendAsync("AtualizarFicha", personagem);
                return;
            }


            context.Entry(personagem).State = EntityState.Detached;

            context.Entry(personagem.Habilidade).State = EntityState.Detached;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao Atualizar Personagem\n" + e.StackTrace);
        }
    }

    public async Task<Personagem> GetPersonagemById(int id)
    {
        Personagem? personagem;
        personagem = await context.Personagens.AsNoTracking().Include(a => a.Habilidade)
            .FirstOrDefaultAsync(p => p.PersonagemId == id);

        if (personagem is null)
        {
            throw new KeyNotFoundException($"Personagem com o id {id} não encontrado.");
        }


        return personagem;
    }

    public async Task<bool> RemovePersonageById(int id)
    {
        context.Personagens.Remove(await GetPersonagemById(id));
        return await context.SaveChangesAsync() > 0;
    }

    public string ObterModificadorHabilidade(int atributo)
    {
        return atributo switch
        {
            18 => "+3",
            >= 16 => "+2",
            >= 13 => "+1",
            >= 9 => "+0",
            >= 6 => "-1",
            >= 4 => "-2",
            _ => "-3" 
        };
    }
}