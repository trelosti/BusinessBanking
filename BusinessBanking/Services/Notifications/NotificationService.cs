using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Domain.Enum;
using BusinessBanking.Domain.Response;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.Notifications;
using BusinessBanking.Repository.Notifications;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace BusinessBanking.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IBaseRepository<Notification> _notificationRepository;

        public NotificationService(IBaseRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<int> Create(NotificationDto notificationDto)
        {
            try
            {
                var notification = new Notification
                {
                    NotificationHeader = notificationDto.NotificationHeader,
                    NotificationBody = Encoding.Unicode.GetBytes(notificationDto.NotificationBody),
                    CreateDate = DateTime.Now,
                    IsSend = false,
                    UserIds = notificationDto.UserIds ?? null
                };

                //string body = Encoding.Unicode.GetString(notification.NotificationBody);

                return await _notificationRepository.Create(notification);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> MarkAsSent(int id)
        {
            var notification = _notificationRepository.GetAll().FirstOrDefault(n => n.ID == id);
            notification.IsSend = true;

            await _notificationRepository.Update(notification);

            return true;
        }
    }
 }

