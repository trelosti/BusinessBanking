using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;


namespace BusinessBanking.Repository.CustomerAccounts
{
    public class CustomerAccountNameRepository : IBaseRepository<CustomerAccountName>
    {
        private readonly DataContext _db;

        public CustomerAccountNameRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public Task<int> Create(CustomerAccountName entity)
        {
            return null;
        }

        public IQueryable<CustomerAccountName> GetAll()
        {
            return _db.CustomerAccountNames;
        }

        public async Task<CustomerAccountName> Update(CustomerAccountName entity)
        {
            _db.CustomerAccountNames.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
