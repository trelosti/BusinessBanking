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
            // Test record
            await _redisCache.SetStringAsync("USER_1", "CHECK");
            await _redisCache.SetStringAsync("USER_2", "CHECK2");

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

            //var deviceToken = await _redisCache.GetStringAsync($"USER_{id}");

            //if (String.IsNullOrEmpty(deviceToken))
            //{
            //    return null;

            //}

            //return deviceToken;
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
