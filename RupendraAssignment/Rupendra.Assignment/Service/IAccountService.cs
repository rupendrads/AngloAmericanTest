using Rupendra.Assignment.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rupendra.Assignment.Service
{
    public interface IAccountService
    {
        Task<IList<Account>> GetAccounts();
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<IList<AccountType>> GetAccountTypes();
    }
}