using Microsoft.AspNetCore.SignalR;

namespace SignalRChatDemo.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAll(string senderId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", senderId, message);
        }

        public async Task SendMessageGroup(string groupId, string senderId, string message)
        {
            await Clients.Group(groupId).SendAsync("ReceiveMessage", senderId, message);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
