namespace CreditSuisseTest.Library
{
    public interface ICashCard
    {
        void Charge(float amount);
        void EnterPIN(string pin);
    }
}