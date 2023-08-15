using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Converters;
using BusinessBanking.Interface.Services.CustomerAccounts;
using BusinessBanking.Services.CustomerAccounts;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BusinessBanking.Converters
{
    public class AccountConverter : IAccountConverter
    {
        private readonly ICurrencyService _currencyService;

        public AccountConverter(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public List<AccountListDto<BaseAccountDto>> ConvertCustomerAccounts(List<CustomerAccount> accounts)
        {
            var result = new List<AccountListDto<BaseAccountDto>>();

            var settlementAccounts = accounts.Where(a => a.AccountType == 0).ToList();
            var depositAccounts = accounts.Where(a => a.AccountType == 1).ToList();
            var cardAccounts = accounts.Where(a => a.AccountType == 2).ToList();

            if (settlementAccounts != null)
            {
                var items = new List<SettlementAccountDto>();

                foreach (var account in settlementAccounts)
                {
                    items.Add(new SettlementAccountDto
                    {
                        AvailableBalance = account.AvailableBalance,
                        Name = account.AccountName,
                        CurrencySymbol = _currencyService.GetCurrencyByID(account.CurrencyID).Result.CurrencySymbol,
                        AccountNo = account.AccountNo,
                        CurrencyID = int.Parse(account.CurrencyID)
                    });
                }

                result.Add(new AccountListDto<BaseAccountDto> 
                { 
                    Text = GetDisplayName(Domain.Enum.AccountType.SettlementAccount),
                    AccountType = Domain.Enum.AccountType.SettlementAccount,
                    Items = items
                });
            }

            if (depositAccounts != null)
            {
                var items = new List<DepositAccountDto>();

                foreach (var account in depositAccounts)
                {
                    items.Add(new DepositAccountDto
                    {
                        OpenDate = account.OpenDate,
                        EndDate = account.EndDate,
                        AvailableBalance = account.AvailableBalance,
                        Name = account.AccountName,
                        CurrencySymbol = _currencyService.GetCurrencyByID(account.CurrencyID).Result.CurrencySymbol,
                        AccountNo = account.AccountNo,
                        CurrencyID = int.Parse(account.CurrencyID)
                    });
                }

                result.Add(new AccountListDto<BaseAccountDto>
                {
                    Text = GetDisplayName(Domain.Enum.AccountType.DepositAccount),
                    AccountType = Domain.Enum.AccountType.DepositAccount,
                    Items = items
                });
            }

            return result;
        }

        private static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }
}
