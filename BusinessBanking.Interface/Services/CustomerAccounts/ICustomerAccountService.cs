using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.CustomerAccounts
{
    public interface ICustomerAccountService
    {
        Task<List<CustomerAccount>> GetAllAccounts();

        Task<List<CustomerAccount>> GetCustomerAccounts(int customerId);
    }
}
