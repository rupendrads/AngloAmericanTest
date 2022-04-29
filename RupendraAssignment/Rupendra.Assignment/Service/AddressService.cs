using Microsoft.Extensions.Logging;
using Rupendra.Assignment.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rupendra.Assignment.Service
{
    public class AddressService : IAddressService
    {
        private readonly IJsonParser _jsonParser;
        private HttpClient _client;
        private ILogger<AddressService> _logger;

        public AddressService(IJsonParser jsonParser,HttpClient client, ILogger<AddressService> logger)
        {
            _client = client;
            _client.BaseAddress = new Uri($"https://randomuser.me/api/");
            _logger = logger;
            _jsonParser = jsonParser;
        }

        public async Task<Address> GetAddress()
        {
            string result;
            var url = new Uri($"?nat=gb", UriKind.Relative);
            result = await _client.GetStringAsync(url);            
            var address = _jsonParser.Parse(result);
            return address;
        }
    }
}
