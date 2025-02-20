using DungeonWorldFIcha.Models;
using Microsoft.AspNetCore.SignalR;

namespace DungeonWorldFIcha.Hubs;

public class PersonagemHub : Hub
{
    public async Task SendMessage(Personagem personagem)
    {
        await Clients.All.SendAsync("AtualizarFicha", personagem);
    }
}