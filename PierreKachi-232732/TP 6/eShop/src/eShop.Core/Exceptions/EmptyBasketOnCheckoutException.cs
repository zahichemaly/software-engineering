namespace eShop.Core.Exceptions
{
    public class EmptyBasketOnCheckoutException : Exception
    {
        public EmptyBasketOnCheckoutException()
            : base($"Basket cannot have 0 items on checkout")
        {
        }
    }
}
