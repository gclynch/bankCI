using Bank;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace BankAcceptanceTest
{
    [Binding]
    public class WithdrawFeatureSteps
    {
        private CurrentAccount account;

        // put the system into known state
        [Given(@"the balance on my account is (.*)")]
        public void GivenTheBalanceOnMyAccountIs(double balance)
        {
            account = new CurrentAccount(balance);
        }

        // put the system into known state
        [Given(@"there is an overdraft limit of (.*) on the account")]
        public void GivenThereIsAnOverdraftLimitOfOnTheAccount(double overdraftlimit)
        {
            account.OverdraftLimit = overdraftlimit;
            // = 0 would cause test to fail
        }

        // user peforms action
        [When(@"I withdraw (.*)")]
        public void WhenIWithdraw(double amount)
        {
            account.Withdraw(amount);
        }

        // observe outcomes
        [Then(@"the balance on the account should be (.*)")]
        public void ThenTheBalanceOnTheAccountShouldBe(double newBalance)
        {
            Assert.AreEqual(account.Balance, newBalance);
        }
    }
}
