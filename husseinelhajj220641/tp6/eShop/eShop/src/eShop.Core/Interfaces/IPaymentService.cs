using eShop.Core.Entities;

namespace eShop.Core.Interfaces
{
    public interface IPaymentService
    {
        void ProcessPayment(CreditCard creditCard, decimal amount);
        decimal GetHoldOfCard(CreditCard creditCard);
    }
}
