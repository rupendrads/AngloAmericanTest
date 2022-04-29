using System;

namespace Rupendra.Assignment.Common
{
    /// <summary>
    /// This is code for The Single Responsibility Principle
    /// In Future in any new behaviour or method needs to include in Silver Account type. we need to add here
    /// </summary>
    public class SilverAccountBalanceChecker: AccountBalanceChecker
    {
        public override bool CheckBalance(decimal amount)
        {
            bool isValidAmount = (amount < 50000) ? true : false;

            if (!isValidAmount)
            {
                throw new ArgumentException("Balance amount should be less than 50000 for Silver account type.");
            }

            return isValidAmount;
        }
    }
}
