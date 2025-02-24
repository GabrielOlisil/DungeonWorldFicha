using DungeonWorldFIcha.Models;

namespace DungeonWorldFIcha.Services.Interfaces;

public interface IPersonagemService
{
    public Task<List<Personagem>> GetPersonagens();
    public Task<bool> AdicionarPersonagem(Personagem personagem);
    public Task AtualizarPersonagem(Personagem personagem);
    public Task<Personagem> GetPersonagemById(int id);
    public Task<bool> RemovePersonageById(int id);
    public string ObterModificadorHabilidade(int atributo);



}