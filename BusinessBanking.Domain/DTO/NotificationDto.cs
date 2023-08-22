using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.DTO
{
    public class NotificationDto
    {
        public string NotificationHeader { get; set; }

        public string NotificationBody { get; set; }

        public string? UserIds { get; set; }

        public string Token { get; set; }
    }
}
