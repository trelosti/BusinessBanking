using Azure.Core;
using BusinessBanking.Domain.DTO;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.Notifications;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IDeviceTokenService _deviceTokenService;

        public NotificationController(INotificationService notificationService, IDeviceTokenService deviceTokenService)
        {
            _notificationService = notificationService;
            _deviceTokenService = deviceTokenService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] NotificationDto notificationDto)
        {
            var notificationID = await _notificationService.Create(notificationDto);

            var notificationData = new Notification
            {
                Title = notificationDto.NotificationHeader,
                Body = notificationDto.NotificationBody
            };

            var ids = notificationDto.UserIds;

            var deviceTokens = await _deviceTokenService.GetDeviceTokens(ids);

            foreach(var token in deviceTokens)
            {
                var message = new Message()
                {
                    Notification = notificationData,

                    Token = token
                };

                var messaging = FirebaseMessaging.DefaultInstance;

                var result = await messaging.SendAsync(message);
            }
            
            await _notificationService.MarkAsSent(notificationID);

            return Ok("The notifications were sent successfully");
        }
    }
}
