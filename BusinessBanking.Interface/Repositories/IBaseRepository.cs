using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> Update(T entity);
    }
}
