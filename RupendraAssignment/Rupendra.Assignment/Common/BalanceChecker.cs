using Rupendra.Assignment.Models;

namespace Rupendra.Assignment.Common
{
    public class BalanceChecker : IBalanceChecker
    {
        private readonly IAccountBalanceChecker _accountBalanceChecker;

        /// <summary>
        ///  This code is Open for extension.
        ///  If new type needs to add future than we need to add new accountype  and create new class of accounttype
        /// </summary>
        /// <param name="accountType"></param>
        public BalanceChecker(EnumAccountTypes accountType)
        {
            switch (accountType)
            {
                case EnumAccountTypes.Gold:
                    _accountBalanceChecker = new GoldAccountBalanceChecker();
                    break;
                case EnumAccountTypes.Bronze:
                    _accountBalanceChecker = new BronzeAccountBalanceChecker();
                    break;
                case EnumAccountTypes.Silver:
                    _accountBalanceChecker = new SilverAccountBalanceChecker();
                    break;
            }
        }

        public bool Process(decimal balaceAmount)
        {
            return _accountBalanceChecker.CheckBalance(balaceAmount);
        }
    }    
}      