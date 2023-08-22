using BusinessBanking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Repositories
{
    public interface IDeviceTokenRepository
    {
        Task<List<string>> GetDeviceTokens(string ids);
    }
}
