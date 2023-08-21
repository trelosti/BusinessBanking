using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Entity
{
    [Table("AccountNames")]
    public class CustomerAccountName
    {
        [Column("ID", Order = 1)]
        public int ID { get; set; }

        [Column("CustomerID", Order = 2)]
        public int CustomerID { get; set; }

        [Column("AccountNo", Order = 3, TypeName = "char(16)")]
        public string AccountNo { get; set; }

        [Column("CurrencyID", Order = 4, TypeName = "char(3)")]
        public string CurrencyID { get; set; }

        [Column("AccountName", Order = 5, TypeName = "varchar(max)")]
        public string AccountName { get; set; }

        public virtual User User { get; set; }

        public virtual CustomerAccount CustomerAccount { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
