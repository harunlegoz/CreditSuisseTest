namespace CreditSuisseTest.Library
{
    public interface IAccount
    {
        float Balance { get; }

        void Withdraw(float amount);
    }
}