using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
