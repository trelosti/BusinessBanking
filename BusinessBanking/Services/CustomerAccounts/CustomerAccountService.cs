using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.CustomerAccounts;
using BusinessBanking.Repository.Users;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BusinessBanking.Services.CustomerAccounts
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly IBaseRepository<CustomerAccount> _customerAccountRepository;

        public CustomerAccountService(IBaseRepository<CustomerAccount> customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public async Task<List<CustomerAccount>> GetAllAccounts()
        {
            return await _customerAccountRepository.GetAll().ToListAsync();
        }

        public async Task<List<CustomerAccount>> GetCustomerAccounts(int customerId)
        {
            return await _customerAccountRepository.GetAll().Where(a => a.CustomerID == customerId).ToListAsync();
        }
    }
}
