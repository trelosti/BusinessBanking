﻿using Azure.Core;
using BusinessBanking.Domain.DTO;
using BusinessBanking.Interface.Services.Notifications;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpPost]
        public async Task<IActionResult> SendMessageAsync([FromBody] NotificationDto notificationDto)
        {
            var notificationID = await _notificationService.Create(notificationDto);

            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = notificationDto.NotificationHeader,
                    Body = notificationDto.NotificationBody,
                },
                Data = new Dictionary<string, string>()
                {
                    ["FirstName"] = "John",
                    ["LastName"] = "Doe"
                },

                Token = notificationDto.Token
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(message);

            if (!string.IsNullOrEmpty(result))
            {
                await _notificationService.MarkAsSent(notificationID);

                return Ok("Message sent successfully!");
            }
            else
            {
                throw new Exception("Error sending the message.");
            }
        }
    }
}
