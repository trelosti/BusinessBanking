using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.Auth;
using BusinessBanking.Interface.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessBanking.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public string GenerateToken(string login, string password)
        {
            if (IsUserValid(login, password))
            {
                var customerID = _userService.GetUserByLogin(login).Result.CustomerID;

                List<Claim> claims = new List<Claim>
                {
                    new Claim("customerID", customerID.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:SecretKey").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var header = new JwtHeader(signingCredentials: creds);
                var payload = new JwtPayload(
                    "example.com", 
                    "example.com", 
                    claims, 
                    null, 
                    expires: DateTime.Now.AddMinutes(20),
                    issuedAt: DateTime.Now
                );

                var token = new JwtSecurityToken(header, payload);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            else
            {
                return null;
            }
        }

        public bool IsUserValid(string login, string password)
        {
            var user = _userService.GetUserByLogin(login).Result;

            if (user == null)
            {
                return false;
            }

            var encrypted = Encrypt(password);
            return user.Password == encrypted;
        }

        private string Encrypt(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
