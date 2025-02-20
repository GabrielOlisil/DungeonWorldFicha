using Microsoft.AspNetCore.SignalR;

namespace DungeonWorldFIcha.Hubs;

public class DadosHub : Hub
{
    public async Task SendMessage(string rolagem)
    {
        await Clients.All.SendAsync("RolarDado", rolagem);
    }
}