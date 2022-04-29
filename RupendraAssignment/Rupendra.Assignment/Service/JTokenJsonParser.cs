using Newtonsoft.Json.Linq;
using Rupendra.Assignment.Models;

namespace Rupendra.Assignment.Service
{
/// <summary>
/// This Class can be extend if any more parse in project.
/// </summary>
    public class JTokenJsonParser : IJsonParser
    {
        public Address Parse(string data)
        {
            JToken token = JToken.Parse(data);
            var city = ((JValue)token.SelectToken("results[0].location.city")).Value;
            var postcode = ((JValue)token.SelectToken("results[0].location.postcode")).Value;
            return new Address { City = city.ToString(), PostCode = postcode.ToString() };
        }
    }
}
