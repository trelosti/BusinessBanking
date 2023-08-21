using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Converters;
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
        private readonly IAccountConverter _accountConverter;

        public CustomerAccountService(IBaseRepository<CustomerAccount> customerAccountRepository, IAccountConverter accountConverter)
        {
            _customerAccountRepository = customerAccountRepository;
            _accountConverter = accountConverter;
        }

        public async Task<List<CustomerAccount>> GetAllAccounts()
        {
            return await _customerAccountRepository.GetAll().ToListAsync();
        }

        public async Task<List<AccountListDto<BaseAccountDto>>> GetCustomerAccounts(int customerId)
        {
            var accounts = await _customerAccountRepository.GetAll().Where(a => a.CustomerID == customerId).ToListAsync();

            accounts.Where(a => a.CustomerAccountName != null).ToList().ForEach(a => a.AccountName = a.CustomerAccountName.AccountName);

            return _accountConverter.ConvertCustomerAccounts(accounts);
        }
    }
}
