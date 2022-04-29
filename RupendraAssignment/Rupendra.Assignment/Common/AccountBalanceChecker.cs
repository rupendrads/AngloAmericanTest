
namespace Rupendra.Assignment.Common
{
    public abstract class AccountBalanceChecker: IAccountBalanceChecker
    {       
        public AccountBalanceChecker()
        {            
        }
        public abstract bool CheckBalance(decimal amount);
    }
}
