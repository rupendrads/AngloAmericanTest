using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rupendra.Assignment.Common;
using System;

namespace Rupendra.Assignment.UnitTest
{
    [TestClass]
    public class BalanceCheckerUnitTests
    {
        [TestMethod]
        public void CheckBalance_Should_Be_True_For_Silver_Account_Valid_Amount()
        {
            // Arrange
            decimal balance = 45000;
            IAccountBalanceChecker balanceChecker = new SilverAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

            // Assert                        
            Assert.IsTrue(result);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckBalance_Should_Be_False_For_Silver_Account_Invalid_Amount()
        {
            // Arrange
            decimal balance = 51000;
            IAccountBalanceChecker balanceChecker = new SilverAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

            // Assert                        
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Balance amount should be less than 50000 for Silver account type.")]
        public void CheckBalance_Should_Return_Error_Message_For_Silver_Account_Invalid_Amount()
        {
            // Arrange
            decimal balance = 51000;
            IAccountBalanceChecker balanceChecker = new SilverAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

        }


        [TestMethod]
        
        public void CheckBalance_Should_Be_True_For_Bronze_Account_Valid_Amount()
        {
            // Arrange
            decimal balance = 51000;
            IAccountBalanceChecker balanceChecker = new BronzeAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

            // Assert                        
            Assert.IsTrue(result);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckBalance_Should_Be_False_For_Bronze_Account_Invalid_Amount()
        {
            // Arrange
            decimal balance = 49000;
            IAccountBalanceChecker balanceChecker = new BronzeAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

            // Assert                        
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Balance amount should be greater than 50001 and less than 100000 for Bronze account type.")]

        public void CheckBalance_Should_Return_Error_Message_For_Bronze_Account_Invalid_Amount()
        {
            // Arrange
            decimal balance = 49000;
            IAccountBalanceChecker balanceChecker = new BronzeAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);
        }

        //////////////////////////

        [TestMethod]
        public void CheckBalance_Should_Be_True_For_Gold_Account_Valid_Amount()
        {
            // Arrange
            decimal balance = 100001;
            IAccountBalanceChecker balanceChecker = new GoldAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

            // Assert                        
            Assert.IsTrue(result);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckBalance_Should_Be_False_For_Gold_Account_Invalid_Amount()
        {
            // Arrange
            decimal balance = 99000;
            IAccountBalanceChecker balanceChecker = new GoldAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);

            // Assert                        
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Balance amount should be greater than 100000 for Gold account type.")]

        public void CheckBalance_Should_Return_Error_Message_For_Gold_Account_Invalid_Amount()
        {
            // Arrange
            decimal balance = 99000;
            IAccountBalanceChecker balanceChecker = new GoldAccountBalanceChecker();

            // Act
            bool result = balanceChecker.CheckBalance(balance);
         }
    }
}
