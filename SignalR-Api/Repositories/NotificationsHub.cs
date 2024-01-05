using Microsoft.AspNetCore.SignalR;
using SignalR_Api.IRepository;
using SignalR_Api.Models;

namespace SignalR_Api.Repositories
{
    public class NotificationsHub : Hub<INotificationClient>
    {
        public async override Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecievedNotification(
                $"Thank you connecting {Context.User?.Identity?.Name}");
            await base.OnConnectedAsync();
        }
    }
    public interface INotificationClient
    { 
        Task RecievedNotification(string message);
    }
}
