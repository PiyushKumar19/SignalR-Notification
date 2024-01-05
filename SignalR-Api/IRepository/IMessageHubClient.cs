using SignalR_Api.Models;

namespace SignalR_Api.IRepository
{
    public interface IMessageHubClient
    {
        Task SendAnnouncement(List<AnnouncementModel> message);
    }
}
