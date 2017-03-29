using System;
using System.Threading;

namespace CreditSuisseTest.Library
{
    public class Account : IAccount
    {
        private float _balance;
        
        public Account(float balance)
        {
            if (balance < 0)
                throw new ArgumentException("Balance cannot be negative.", "balance");

            _balance = balance;
        }

        public float Balance
        {
            get
            {
                lock (this)
                {
                    return _balance;
                }
            }
        }

        public void Withdraw(float amount)
        {
            lock (this)
            {
                if (amount < 0)
                    throw new InvalidAmountException();

                if (_balance - amount < 0)
                    throw new NotEnoughBalanceException();

                _balance -= amount;
            }
        }
    }
}