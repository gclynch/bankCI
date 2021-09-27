using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank;

namespace BankUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]                                            // a unit test
        public void TestDeposit1()
        {
            // 0 balance
            CurrentAccount acc = new CurrentAccount();
            acc.Deposit(100);
            acc.Deposit(200);
            Assert.AreEqual(301, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]           // should throw an ArgumentException (or subclass) otherwise test fails
        public void CreateAccountWithInvalidOverdraftLimit()
        {
            CurrentAccount acc = new CurrentAccount(-5000);
        }

        [TestMethod]
        public void TestDepositAndWithdrawal1()
        {
            CurrentAccount acc = new CurrentAccount();
            acc.Deposit(100);
            acc.Withdraw(50);
            acc.Deposit(150);
            Assert.AreEqual(200, acc.Balance);
        }

        [TestMethod]
        public void TestDepositAndWithdrawal2()                 // overdraw the account
        {
            CurrentAccount acc = new CurrentAccount();
            acc.OverdraftLimit = 1000;
            acc.Deposit(100);
            acc.Withdraw(1000);
            Assert.AreEqual(-900, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal3()
        {
            CurrentAccount acc = new CurrentAccount();
            acc.Deposit(-100);                                  // must be positive
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDepositAndWithdrawal4()
        {
            CurrentAccount acc = new CurrentAccount();
            acc.Deposit(100);
            acc.Withdraw(0);                                    // must be positive
        }
    }
}
