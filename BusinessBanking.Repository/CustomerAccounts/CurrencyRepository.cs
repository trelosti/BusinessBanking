using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Repository.CustomerAccounts
{
    public class CurrencyRepository : IBaseRepository<Currency>
    {
        private readonly DataContext _db;

        public CurrencyRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public Task<int> Create(Currency entity)
        {
            return null;
        }

        public IQueryable<Currency> GetAll()
        {
            return _db.Currencies;
        }

        // TODO: Implement in future (maybe)
        public Task<Currency> Update(Currency entity)
        {
            return null;
        }
    }
}
