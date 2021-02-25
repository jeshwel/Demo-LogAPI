using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_LogAPI.Auth
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        //for test purpose we are storing the keys in memory, but in real app we should use persistent storage.
        public InMemoryGetApiKeyQuery()
        {
            var existingApiKeys = new List<ApiKey>
        {
            new ApiKey(1, "DemoClient", "key3e5847c8449a5ac5cd72b7ad8c0a3", DateTime.Now ,
                new List<string>
                {
                    Roles.User, //Add roles as necessary here.
                })
        };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }

}
