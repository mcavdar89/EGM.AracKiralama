using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace EGM.AracKiralama.API.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> ConnectedUsers = new();
        public ChatHub()
        {
            
        }

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            string userName = Context.GetHttpContext()?.Request.Query["username"];

            if (!String.IsNullOrEmpty(userName))
            {
                ConnectedUsers.TryAdd(userName, connectionId);
                await Clients.All.SendAsync("userConnected",userName);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string connectionId = Context.ConnectionId;
            if(ConnectedUsers.TryRemove(connectionId,out string? username))
            {
                await Clients.All.SendAsync("userDisconnected", username);
            }

            await base.OnDisconnectedAsync(exception);
        }


        public async Task SendMessageToAll(string username, string message)
        {
            await Clients.All.SendAsync("receiveMessage",username, message);
        }



        public async Task SendMessage(string to, string message)
        {
            if (ConnectedUsers.TryGetValue(to, out string? connectionId))
            {
                await Clients.Client(connectionId).SendAsync("receiveMessage", message);
            }
        }



    }
}
