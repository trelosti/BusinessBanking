using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Enum
{
    public enum AccountType
    {
        [Display(Name = "Расчетные счета")]
        SettlementAccount = 0,
        [Display(Name = "Депозитные счета")]
        DepositAccount = 1,
        [Display(Name = "Карточные счета")]
        CardAccount = 2
    }
}
