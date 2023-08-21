using BusinessBanking.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.CustomerAccounts
{
    public interface ICustomerAccountNameService
    {
        Task<CustomerAccountNameDto> CustomerAccountRename(CustomerAccountNameDto customerAccountName);
    }
}
