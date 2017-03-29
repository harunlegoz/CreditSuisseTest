using System;

namespace CreditSuisseTest.Library
{
    public class VendingMachine : IVendingMachine
    {
        private const int _price = 50;
        
        public VendingMachine()
        {
        }

        public int Count { get; private set; } = 25;

        public void Vend(int requestedCount, ICashCard cashCard, string pin)
        {
            if (cashCard == null)
                throw new ArgumentNullException("cashCard");

            if (string.IsNullOrEmpty(pin))
                throw new ArgumentNullException("pin");

            if (requestedCount > Count)
                throw new NotEnoughItemsException();

            var amount = requestedCount * _price;

            cashCard.EnterPIN(pin);
            cashCard.Charge(amount);

            Decrease(requestedCount);
        }

        private void Decrease(int requestedCount)
        {
            Count -= requestedCount;
        }
    }
}