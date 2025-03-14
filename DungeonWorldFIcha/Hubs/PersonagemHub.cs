using DungeonWorldFIcha.Models;
using Microsoft.AspNetCore.SignalR;

namespace DungeonWorldFIcha.Hubs;

public class PersonagemHub : Hub
{
    public async Task SendMessage(Personagem personagem)
    {
        await Clients.All.SendAsync("AtualizarFicha", personagem);
    }
    
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
    
    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }
}