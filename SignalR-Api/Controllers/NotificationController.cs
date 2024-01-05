//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using SignalR_Api.IRepository;
//using SignalR_Api.Models;
//using SignalR_Api.Repositories;

//namespace SignalR_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NotificationController : ControllerBase
//    {
//        private readonly IHubContext<MessageHub, IMessageHubClient> hubContext;

//        public NotificationController(IHubContext<MessageHub, IMessageHubClient> hubContext)
//        {
//            this.hubContext = hubContext;
//        }

//        [HttpGet]
//        public async Task<ActionResult> SendAnnounces(string message)
//        {
//            int a = 0;
//            var announcements = new List<AnnouncementModel>()
//            {
//                new AnnouncementModel() { Author = "Piyush", Message = $"Hello {a = a+1}"},
//                new AnnouncementModel() { Author = "Piyush", Message = $"Hello {a = a+1}"},
//            };
//            await hubContext.Clients.All.SendAnnouncement(announcements);
//            return Ok(announcements);
//        }
//    }
//}
