using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.CustomerAccounts;
using Microsoft.EntityFrameworkCore;

namespace BusinessBanking.Services.CustomerAccounts
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IBaseRepository<Currency> _currencyRepository;

        public CurrencyService(IBaseRepository<Currency> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<List<Currency>> GetAllCurrencies()
        {
            return await _currencyRepository.GetAll().ToListAsync();
        }

        public async Task<Currency> GetCurrencyByID(string currencyId)
        {
            return await _currencyRepository.GetAll().Where(c => c.CurrencyID == currencyId).FirstOrDefaultAsync();
        }
    }
}
