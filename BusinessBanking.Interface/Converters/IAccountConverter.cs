using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Converters
{
    public interface IAccountConverter
    {
        List<AccountListDto<BaseAccountDto>> ConvertCustomerAccounts(List<CustomerAccount> accounts);
    }
}
