using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.CustomerAccounts;
using BusinessBanking.Repository.CustomerAccounts;
using Microsoft.EntityFrameworkCore;

namespace BusinessBanking.Services.CustomerAccounts
{
    public class CustomerAccountNameService : ICustomerAccountNameService
    {
        private readonly IBaseRepository<CustomerAccountName> _customerAccountNameRepository;

        public CustomerAccountNameService(IBaseRepository<CustomerAccountName> customerAccountNameRepository)
        {
            _customerAccountNameRepository = customerAccountNameRepository;
        }

        public async Task<CustomerAccountNameDto> CustomerAccountRename(CustomerAccountNameDto customerAccountNameDto)
        {
            var customerAccountName = await _customerAccountNameRepository.GetAll().FirstOrDefaultAsync(
                ca => ca.AccountNo == customerAccountNameDto.AccountNo &&
                ca.CurrencyID == customerAccountNameDto.CurrencyID);

            if (customerAccountName != null)
            {
                customerAccountName.AccountName = customerAccountNameDto.AccountName;

                await _customerAccountNameRepository.Update(customerAccountName);

                return new CustomerAccountNameDto
                {
                    AccountNo = customerAccountName.AccountNo,
                    CurrencyID = customerAccountName.CurrencyID,
                    AccountName = customerAccountName.AccountName
                };
            }

            return customerAccountNameDto;
        }
    }
}
