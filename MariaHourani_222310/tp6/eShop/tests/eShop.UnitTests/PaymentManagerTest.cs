using System;
using System.Linq;
using eShop.Core.Entities;
using eShop.Core.Exceptions;
using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;
using Xunit;

namespace eShop.Core.Tests.Managers
{
    public class PaymentManagerTests
    {
        private readonly Mock<IPaymentService> _paymentServiceMock;
        private readonly Mock<IAppLogger<PaymentManager>> _loggerMock;
        private readonly PaymentManager _paymentManager;

        public PaymentManagerTests()
        {
            _paymentServiceMock = new Mock<IPaymentService>();
            _loggerMock = new Mock<IAppLogger<PaymentManager>>();
            _paymentManager = new PaymentManager(_paymentServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void ValidateAndPlaceOrder_WithEmptyBasket_ThrowsEmptyBasketOnCheckoutException()
        {
            var order = CreateOrderWithBasket();
            typeof(Order).GetProperty("Basket")?.SetValue(order, new Basket("id10"));
            Assert.Throws<EmptyBasketOnCheckoutException>(() => _paymentManager.ValidateAndPlaceOrder(order));
        }

        [Fact]
        public void ValidateAndPlaceOrder_WithExpiredCreditCard_ThrowsCreditCardExpiredException()
        {
            var order = CreateOrderWithBasket();
            var basket = new Basket("id12");
            basket.AddItem(1, 10.0m, 1);

            typeof(Order).GetProperty("Basket")?.SetValue(order, basket);
            order.CreditCard = new CreditCard { Expiration = DateTime.UtcNow.AddSeconds(-1) };
            order.Contact = new Contact();

            Assert.Throws<CreditCardExpiredException>(() => _paymentManager.ValidateAndPlaceOrder(order));
        }


        private Order CreateOrderWithBasket()
        {
            return new Order(new Basket("id2"), new Contact(), new CreditCard());
        }
    }
}
