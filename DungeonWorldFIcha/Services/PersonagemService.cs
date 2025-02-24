using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Hubs;
using DungeonWorldFIcha.Models;
using DungeonWorldFIcha.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DungeonWorldFIcha.Services;

public class PersonagemService : IPersonagemService
{
    private readonly DungeonWorldContext _context;
    private readonly IHubContext<PersonagemHub> _personagemHub;

    public PersonagemService(DungeonWorldContext context, IHubContext<PersonagemHub> personagemHub)
    {
        _context = context;
        _personagemHub = personagemHub;
    }

    public async Task<List<Personagem>> GetPersonagens()
    {
        List<Personagem> list;
        list = await _context.Personagens.AsNoTracking().Include(p => p.Habilidade).ToListAsync();
        return list;
    }

    public async Task<bool> AdicionarPersonagem(Personagem personagem)
    {
        _context.Personagens.Add(personagem);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task AtualizarPersonagem(Personagem personagem)
    {
        try
        {
            _context.Personagens.Update(personagem);


            if (await _context.SaveChangesAsync() > 0)
            {
                _context.Entry(personagem).State = EntityState.Detached;

                _context.Entry(personagem.Habilidade).State = EntityState.Detached;

                await _personagemHub.Clients.All.SendAsync("AtualizarFicha", personagem);
                return;
            }


            _context.Entry(personagem).State = EntityState.Detached;

            _context.Entry(personagem.Habilidade).State = EntityState.Detached;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao Atualizar Personagem\n" + e.StackTrace);
        }
    }

    public async Task<Personagem> GetPersonagemById(int id)
    {
        Personagem? personagem = null;
        personagem = await _context.Personagens.AsNoTracking().Include(a => a.Habilidade)
            .FirstOrDefaultAsync(p => p.PersonagemId == id);

        if (personagem is null)
        {
            throw new KeyNotFoundException($"Personagem com o id {id} não encontrado.");
        }


        return personagem;
    }

    public async Task<bool> RemovePersonageById(int id)
    {
        _context.Personagens.Remove(await GetPersonagemById(id));
        return await _context.SaveChangesAsync() > 0;
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