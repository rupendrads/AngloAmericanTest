using Rupendra.Assignment.Models;
using System.Threading.Tasks;

namespace Rupendra.Assignment.Service
{
    public interface IAddressService
    {
        Task<Address> GetAddress();
    }
}