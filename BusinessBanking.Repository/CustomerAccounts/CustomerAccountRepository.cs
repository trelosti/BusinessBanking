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
    public class CustomerAccountRepository : IBaseRepository<CustomerAccount>
    {
        private readonly DataContext _db;

        public CustomerAccountRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public Task<int> Create(CustomerAccount entity)
        {
            return null;
        }

        public IQueryable<CustomerAccount> GetAll()
        {
            return _db.CustomerAccounts;
        }

        // TODO: Implement in future (maybe)
        public Task<CustomerAccount> Update(CustomerAccount entity)
        {
            return null;
        }
    }
}
