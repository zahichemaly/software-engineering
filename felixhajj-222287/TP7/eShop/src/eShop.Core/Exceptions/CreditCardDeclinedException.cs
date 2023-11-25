namespace eShop.Core.Exceptions
{
    public abstract class CreditCardDeclinedException : Exception
    {
        public CreditCardDeclinedException(string message): 
            base(message)
        {
        }
    }

    public class CreditCardInsufficientAmountException: CreditCardDeclinedException
    {
        public CreditCardInsufficientAmountException(decimal amountToPay) :
            base($"Credit card does not have the required amount {amountToPay}")
        {
        }
    }

    public class CreditCardExpiredException : CreditCardDeclinedException
    {
        public CreditCardExpiredException(DateTime expiration) :
            base($"Credit card has already expired since {expiration:yyyy-MM-ddd}")
        {
        }
    }
}
