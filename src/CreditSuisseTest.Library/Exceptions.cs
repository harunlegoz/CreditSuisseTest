using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTest.Library
{
    public abstract class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {

        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }

    public class InvalidAmountException : BusinessException
    {
        public InvalidAmountException()
            : base("Specified amount is not valid for this card.")
        {

        }
    }

    public class NotEnoughBalanceException : BusinessException
    {
        public NotEnoughBalanceException()
            : base("Not enough balance in the account for this operation.")
        {

        }
    }

    public class UnauthorizedCardException : BusinessException
    {
        public UnauthorizedCardException()
            : base("Card is unauthorized for this operation.")
        {

        }
    }

    public class NotEnoughItemsException : BusinessException
    {
        public NotEnoughItemsException()
            : base("Not enough items in the vending machine.")
        {

        }
    }
}
