using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Entity
{
    [Table("Currencies")]
    public class Currency
    {
        [Column("ID", Order = 1)]
        public int ID { get; set; }

        [Column("CurrencyID", Order = 2, TypeName = "char(3)")]
        public string CurrencyID { get; set; }

        [Column("CurrencySymbol", Order = 3, TypeName = "varchar(500)")]
        public string CurrencySymbol { get; set; }

        [Column("CurrencyName", Order = 4, TypeName = "varchar(500)")]
        public string CurrencyName { get; set; }

        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; }
    }
}
