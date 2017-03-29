namespace CreditSuisseTest.Library
{
    public interface IVendingMachine
    {
        int Count { get; }

        void Vend(int requestedCount, ICashCard cashCard, string pin);
    }
}