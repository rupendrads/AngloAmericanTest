using Rupendra.Assignment.Models;

namespace Rupendra.Assignment.Service
{
    public interface IJsonParser
    {
        Address Parse(string data);
    }
}
