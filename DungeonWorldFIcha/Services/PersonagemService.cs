using DungeonWorldFIcha.Database;
using DungeonWorldFIcha.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeonWorldFIcha.Services;


public class PersonagemService
{
    private readonly DungeonWorldContext _context;

    public PersonagemService(DungeonWorldContext context)
    {
        _context = context;
    }

    public async Task<List<Personagem>> GetPersonagens()
    {
        List<Personagem> list;
         list =  await _context.Personages.Include(p => p.Habilidade).ToListAsync();
         return list;
    }

    public async Task<bool> AdicionarPersonagem(Personagem personagem)
    {
        _context.Personages.Add(personagem);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task AtualizarPersonagem(Personagem personagem)
    {
        try
        {
            _context.Personages.Update(personagem);
            await _context.SaveChangesAsync();

        }
        catch (Exception e)
        {
            throw new ArgumentException("Erro ao Atualizar Personagem\n" + e.StackTrace);
        }
    }

    public async Task<Personagem> GetPersonagemById(Guid id)
    {
        Personagem? personagem = null;
        personagem = await _context.Personages.Include(a => a.Habilidade)
            .FirstOrDefaultAsync(p => p.PersonagemId == id);

        if (personagem is null)
        {
            throw new KeyNotFoundException($"Personagem com o id {id} não encontrado.");
        }


        return personagem;
    }

    public async Task<bool> RemovePersonageById(Guid id)
    {
        _context.Personages.Remove(await GetPersonagemById(id));
        return await _context.SaveChangesAsync() > 0;
    }
}