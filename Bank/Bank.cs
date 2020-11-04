// a bank account
// Unit tests (MSTest) and
// Specflow acceptance tests in a separate test project

using System;

namespace Bank
{
    // a simple euro current bank account
    public class CurrentAccount
    {
        public double balance;                             // the account balance
        private double overdraftLimit;

        // + account number etc.

        // construct a bank acocunt with specified opening balance
        public CurrentAccount(double openingbalance)
        {
            if (openingbalance >= 0)
            {
                this.balance = openingbalance;
            }
            else
            {
                throw new ArgumentException("opening balance must be >= 0");
            }

        }

        // chain, 0 balance
        public CurrentAccount() : this(0)
        {

        }

        // read-only property
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        // property
        public double OverdraftLimit
        {
            get
            {
                return overdraftLimit;
            }
            set
            {
                if (value >= 0)
                {
                    this.overdraftLimit = value;
                }
                else
                {
                    throw new ArgumentException("overdraft limit must be >= 0");
                }
            }
        }

        // deposit some money
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                throw new ArgumentException("amount must be > 0");
            }
        }

        // withdraw some money if sufficient funds
        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (balance + overdraftLimit >= amount)
                {
                    balance -= amount;
                }
                else
                {
                    throw new ArgumentException("Insufficent funds for this transaction");
                }
            }
            else
            {
                throw new ArgumentException("amount must be > 0");
            }
        }

    }
}

