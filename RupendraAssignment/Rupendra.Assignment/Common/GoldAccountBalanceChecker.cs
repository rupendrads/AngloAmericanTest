using System;

namespace Rupendra.Assignment.Common
{
    /// <summary>
    /// This is code for The Single Responsibility Principle
    /// In Future in any new behaviour or method needs to include in Gold Account type. we need to add here
    /// </summary>
    public class GoldAccountBalanceChecker : AccountBalanceChecker
    {
        public override bool CheckBalance(decimal amount)
        {
            bool isValidAmount = (amount > 100000) ? true : false;
            
            if (!isValidAmount)
            {
                throw new ArgumentException("Balance amount should be greater than 100000 for Gold account type.");
            }

            return isValidAmount;
        }
    }
}
