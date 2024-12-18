using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace EGM.AracKiralama.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> ConnectedUsers = new();
        public ChatHub()
        {
            
        }

        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            string userName = Context.GetHttpContext()?.User?.Claims.FirstOrDefault(d => d.Type == "ad").Value;
                
                
                //Context.GetHttpContext()?.Request.Query["access_Token"];

            if (!String.IsNullOrEmpty(userName))
            {
                ConnectedUsers.TryAdd(userName, connectionId);
                await Clients.All.SendAsync("userConnected",userName);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            string userName = Context.GetHttpContext()?.User?.Claims.FirstOrDefault(d => d.Type == "ePosta").Value;
            string connectionId = Context.ConnectionId;
            if(ConnectedUsers.TryRemove(userName, out string? id))
            {
                await Clients.All.SendAsync("userDisconnected", userName);
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
