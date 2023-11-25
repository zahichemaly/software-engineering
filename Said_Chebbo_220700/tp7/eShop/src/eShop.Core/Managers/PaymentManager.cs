using eShop.Core.Entities;
using eShop.Core.Exceptions;
using eShop.Core.Interfaces;

namespace eShop.Core.Managers
{
    /// <summary>
    /// Validates the <see cref="Order"/> and processes it using <see cref="IPaymentService"/>.
    /// </summary>
    public class PaymentManager
    {
        private readonly IPaymentService _paymentService;
        private readonly IAppLogger<PaymentManager> _logger;

        public PaymentManager(IPaymentService paymentService, IAppLogger<PaymentManager> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        public decimal ValidateAndPlaceOrder(Order order)
        {
            _logger.LogInformation("Started placing the order");

            if (!order.Basket.Items.Any())
            {
                throw new EmptyBasketOnCheckoutException();
            }

            var amountToPay = order.Basket.GetTotalPrice();

            // Check for expiration first
            if (order.CreditCard.Expiration <= DateTime.UtcNow)
            {
                throw new CreditCardExpiredException(order.CreditCard.Expiration);
            }

            // Try to get hold off the card and check the amount
            var cardHoldAmount = _paymentService.GetHoldOfCard(order.CreditCard);
            if (amountToPay <= cardHoldAmount)
            {
                throw new CreditCardInsufficientAmountException(amountToPay);
            }

            // We can place the payment
            _paymentService.ProcessPayment(order.CreditCard, amountToPay);

            _logger.LogInformation("Finished placing the order");

            // This is just for educational purposes...
            var remaining = cardHoldAmount - amountToPay;
            return remaining;
        }
    }
}
