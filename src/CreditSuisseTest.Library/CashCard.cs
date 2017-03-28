using System;

namespace CreditSuisseTest.Library
{
    public class CashCard
    {
        private Account _account;
        private string _pinCode;
        private bool _unlocked = false;

        public CashCard(Account account, string pinCode)
        {
            this._account = account;
            this._pinCode = pinCode;
        }

        public void Charge(float amount)
        {
            CheckLock();

            _account.Withdraw(amount);
        }

        public void EnterPIN(string pin)
        {
            if (_unlocked)
                throw new InvalidOperationException("CashCard is already unlocked.");

            if (string.Equals(_pinCode, pin, StringComparison.Ordinal))
                _unlocked = true;
            else
                throw new UnauthorizedCardException();
        }

        private void CheckLock()
        {
            if (!_unlocked)
                throw new UnauthorizedCardException();
        }
    }
}