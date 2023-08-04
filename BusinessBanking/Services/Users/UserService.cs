using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace BusinessBanking.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetAll().ToListAsync();
        }
    }
}
