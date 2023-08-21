using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Entity
{
    [Table("Notifications")]
    public class Notification
    {
        [Column("ID", Order = 1)]
        public int ID { get; set; }

        [Column("NotificationHeader", Order = 2, TypeName = "varchar(500)")]
        public string NotificationHeader { get; set; }

        [Column("NotificationBody", Order = 3, TypeName = "image")]
        public byte[] NotificationBody { get; set; }

        [Column("CreateDate", Order = 4, TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [Column("IsSend", Order = 5, TypeName = "bit")]
        public bool IsSend { get; set; }

        [Column("UserIDs", Order = 6, TypeName = "varchar(max)")]
        public string? UserIds { get; set; }
    }
}
