using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Repository.Notifications
{
    public class DeviceTokenRepository : IDeviceTokenRepository
    {
        private readonly IDistributedCache _redisCache;

        public DeviceTokenRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<List<string>> GetDeviceTokens(string ids)
        {
            //await _redisCache.SetStringAsync("USER_1", "fy74Eh3_lQUxLzeB3RL3Xd:APA91bFc00tHxW_P-RuxzEXcpeMQyde8jfM0-hEp6Hfos7Dh2o7YG0yIRDhfhD10b6oBtZtgjeRnOj4evdhgmA2AG3vk8SukXUTtNeraUYlCBmhS8zE26pB7jjVFHss_AlPkOHhI7K2X");

            var userIds = ParseStringToArray(ids);

            var tokens = new List<string>();

            foreach(var userId in userIds) 
            {
                var deviceToken = await _redisCache.GetStringAsync($"USER_{userId}");

                if (deviceToken != null)
                {
                    tokens.Add(deviceToken);
                }
            }

            return tokens;
        }

        public async Task<List<string>> GetDeviceTokens(string[] ids)
        {
            // Test records
            //await _redisCache.SetStringAsync("USER_1", "fy74Eh3_lQUxLzeB3RL3Xd:APA91bFc00tHxW_P-RuxzEXcpeMQyde8jfM0-hEp6Hfos7Dh2o7YG0yIRDhfhD10b6oBtZtgjeRnOj4evdhgmA2AG3vk8SukXUTtNeraUYlCBmhS8zE26pB7jjVFHss_AlPkOHhI7K2X");

            var tokens = new List<string>();

            foreach (var userId in ids)
            {
                var deviceToken = await _redisCache.GetStringAsync($"USER_{userId}");

                if (deviceToken != null)
                {
                    tokens.Add(deviceToken);
                }
            }

            return tokens;
        }

        public async Task<bool> SaveDeviceToken(int userID, string token)
        {
            try
            {
                await _redisCache.SetStringAsync($"USER_{userID}", token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string[] ParseStringToArray(string input)
        {
            string[] elements = input.Split(',')
                                 .Select(part => part.Trim()) 
                                 .Where(part => !string.IsNullOrEmpty(part)) 
                                 .ToArray();

            return elements;
        }
    }
}
