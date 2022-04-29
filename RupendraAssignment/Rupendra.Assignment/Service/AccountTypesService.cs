using Rupendra.Assignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rupendra.Assignment.Service
{
    public class AccountTypesService
    {
        private readonly AccountContext _accountContext;

        public AccountTypesService(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public async Task<IList<AccountType>> GetAccountTypes()
        {
            var accountTypes = _accountContext.AccountTypes;
            return await Task.Run(() => accountTypes.ToList());
        }
    }
}
