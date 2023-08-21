using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.DTO
{
    public class CustomerAccountNameDto
    {
        public string AccountNo { get; set; }
        public string CurrencyID { get; set; }
        public string AccountName { get; set; }
    }
}
