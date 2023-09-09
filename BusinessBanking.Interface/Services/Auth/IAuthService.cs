using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Interface.Services.Auth
{
    public interface IAuthService
    {
        string GenerateToken(string login, string password);

        bool IsUserValid(string login, string password);

        int FindUserId(string login);
    }
}
