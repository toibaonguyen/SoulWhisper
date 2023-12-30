// ChatHub.cs
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace soul_whisper.Hubs;
public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
