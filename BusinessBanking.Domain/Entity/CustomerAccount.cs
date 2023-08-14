using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Entity
{
    [Table("CustomerAccounts")]
    public class CustomerAccount
    {
        [Column("ID", Order = 1)]
        public int ID { get; set; }

        [Column("CustomerID", Order = 2)]
        public int CustomerID { get; set; }

        [Column("AccountType", Order = 3, TypeName = "tinyint")]
        public byte AccountType { get; set; }

        [Column("AccountNo", Order = 4, TypeName = "char(16)")]
        public string AccountNo { get; set; }

        [Column("CurrencyID", Order = 5, TypeName = "char(3)")]
        public string CurrencyID { get; set; }

        [Column("AccountName", Order = 6, TypeName = "varchar(500)")]
        public string AccountName { get; set; }

        [Column("AvailableBalance", Order = 7, TypeName = "decimal(17,2)")]
        public decimal AvailableBalance { get; set; }

        [Column("OpenDate", Order = 8, TypeName = "date")]
        public DateTime OpenDate { get; set; }

        [Column("EndDate", Order = 9, TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column("CloseDate", Order = 10, TypeName = "date")]
        public DateTime? CloseDate { get; set; }

        public virtual User User { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
