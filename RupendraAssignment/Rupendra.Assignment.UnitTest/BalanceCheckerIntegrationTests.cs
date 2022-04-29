using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rupendra.Assignment.Common;

namespace Rupendra.Assignment.UnitTest
{
    [TestClass]
    public class BalanceCheckerIntegrationTests
    {
        [TestMethod]
        public void Process_Should_Verify_Silver_Account_Valid_Amount()
        {
            // Arrange
            decimal balance = 45000;
            IBalanceChecker balanceChecker = new BalanceChecker(Models.EnumAccountTypes.Silver);

            // Act
            bool result = balanceChecker.Process(balance);

            // Assert                        
            Assert.IsTrue(result);           
        }

        [TestMethod]
        public void Process_Should_Verify_Bronze_Account_Valid_Amount()
        {
            // Arrange
            decimal balance = 51000;
            IBalanceChecker balanceChecker = new BalanceChecker(Models.EnumAccountTypes.Bronze);

            // Act
            bool result = balanceChecker.Process(balance);

            // Assert                        
            Assert.IsTrue(result);
           
        }

        [TestMethod]
        public void Process_Should_Verify_Gold_Account_Valid_Amount()
        {
            // Arrange
            decimal balance = 100001;
            IBalanceChecker balanceChecker = new BalanceChecker(Models.EnumAccountTypes.Gold);

            // Act
            bool result = balanceChecker.Process(balance);

            // Assert                        
            Assert.IsTrue(result);
           
        }
    }
}
