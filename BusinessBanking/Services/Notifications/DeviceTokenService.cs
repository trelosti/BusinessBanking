using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.Notifications;

namespace BusinessBanking.Services.Notifications
{
    public class DeviceTokenService : IDeviceTokenService
    {
        private readonly IDeviceTokenRepository _deviceTokenRepository;
        private readonly IBaseRepository<User> _userRepository;

        public DeviceTokenService(IDeviceTokenRepository deviceTokenRepository, IBaseRepository<User> userRepository)
        {
            _deviceTokenRepository = deviceTokenRepository;
            _userRepository = userRepository;
        }

        public Task<List<string>> GetDeviceTokens(string ids)
        {
            if (ids != null)
            {
                return _deviceTokenRepository.GetDeviceTokens(ids);
            }
            else
            {
                var userIds = _userRepository.GetAll().Select(u => u.ID.ToString()).ToArray();

                return _deviceTokenRepository.GetDeviceTokens(userIds);
            }
        }
    }
}
