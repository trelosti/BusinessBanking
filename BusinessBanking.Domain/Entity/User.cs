using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Column("ID", Order = 1)]
        public int ID { get; set; }

        [Column("CustomerID", Order = 2)]
        public int CustomerID { get; set; }

        [Column("Login", Order = 3, TypeName = "char(25)")]
        public string Login { get; set; }

        [Column("Password", Order = 4, TypeName = "nvarchar(max)")]
        public string Password { get; set; }

        [Column("UserAccess", Order = 5)]
        public int UserAccess { get; set; }

        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set;}
    }
}
