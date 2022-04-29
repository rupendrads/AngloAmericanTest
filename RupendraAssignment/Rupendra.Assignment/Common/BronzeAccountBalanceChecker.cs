using System;

namespace Rupendra.Assignment.Common
{    
     /// <summary>
     /// This is code for The Single Responsibility Principle
     /// In Future in any new behaviour or method needs to include in Bronze Account type. we need to add here
     /// </summary>
    public class BronzeAccountBalanceChecker : AccountBalanceChecker
    {
        public override bool CheckBalance(decimal amount)
        {
            bool isValidAmount = (amount > 50001 && amount < 100000) ? true : false;

            if (!isValidAmount)
            {
                throw new ArgumentException("Balance amount should be greater than 50001 and less than 100000 for Bronze account type.");
            }

            return isValidAmount;
        }
    }
}
