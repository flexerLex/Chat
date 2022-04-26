using Chat.Database.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDbService _dbService;
        public ChatHub(IDbService service)
        {
            _dbService = service;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            await _dbService.AddUserAsync(new User() { UserName = user});
        }
    }
}