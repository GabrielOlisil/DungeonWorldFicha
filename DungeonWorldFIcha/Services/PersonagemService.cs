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
        return await _context.Personages.Include(p => p.Habilidade).ToListAsync();
    }

    public async Task AdicionarPersonagem(Personagem personagem)
    {
        _context.Personages.Add(personagem);
        await _context.SaveChangesAsync();
    }
}