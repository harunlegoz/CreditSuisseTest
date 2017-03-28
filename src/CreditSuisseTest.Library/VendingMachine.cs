using System;

namespace CreditSuisseTest.Library
{
    public class VendingMachine
    {
        private int _count = 25;
        private int _price = 50;

        public VendingMachine()
        {
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Vend(int requestedCount, CashCard cashCard, string pin)
        {
            if (cashCard == null)
                throw new ArgumentNullException("cashCard");

            if (string.IsNullOrEmpty(pin))
                throw new ArgumentNullException("pin");

            if (requestedCount > _count)
                throw new NotEnoughItemsException();

            var amount = requestedCount * _price;

            cashCard.EnterPIN(pin);
            cashCard.Charge(amount);

            _count -= requestedCount;
        }
    }
}