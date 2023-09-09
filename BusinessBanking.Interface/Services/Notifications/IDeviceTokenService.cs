using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.Notifications
{
    public interface IDeviceTokenService
    {
        Task<List<string>> GetDeviceTokens(string ids);

        Task<bool> SaveDeviceToken(int userID, string token);
    }
}
