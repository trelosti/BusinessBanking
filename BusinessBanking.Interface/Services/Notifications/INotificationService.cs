using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.Notifications
{
    public interface INotificationService
    {
        Task<int> Create(NotificationDto notificationDto);

        Task<bool> MarkAsSent(int id);
    }
}
