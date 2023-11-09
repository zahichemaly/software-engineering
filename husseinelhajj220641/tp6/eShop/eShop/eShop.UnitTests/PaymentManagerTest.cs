using eShop.Core.Entities;
using eShop.Core.Exceptions;
using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UnitTests
{
    public class PaymentManagerTest
    {
        private readonly Mock<IPaymentService> _paymentServiceMock;
        private readonly Mock<IAppLogger<PaymentManager>> _loggerMock;
        private readonly PaymentManager _paymentManager;

        public PaymentManagerTest()
        {
            _paymentServiceMock = new Mock<IPaymentService>();
            _loggerMock = new Mock<IAppLogger<PaymentManager>>();
            _paymentManager = new PaymentManager(_paymentServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void ValidateAndPlaceOrder_ThrowsEmptyBasketOnCheckoutException_IfBasketIsEmpty()
        {
            var order = new Order(new Basket("buyerId"), new Contact("testing@hello.com", "876545678"), new CreditCard(CreditCardType.VISA, "testing", "9876545678", DateTime.UtcNow.AddMonths(1), "uhgbnjuygbn", 200));

            Assert.Throws<EmptyBasketOnCheckoutException>(() => _paymentManager.ValidateAndPlaceOrder(order));
        }

        [Fact]
        public void ValidateAndPlaceOrder_ThrowsCreditCardExpiredException_IfCardIsExpired()
        {
            var basket = new Basket("igfskhbv");
            basket.Items = new List<BasketItem> { new BasketItem(1, 1, 10m) };
            var date = new DateTime();
            date.Subtract(new DateTime(2019, 05, 09, 9, 15, 0));
            var order = new Order(basket, new Contact("testing@hello.com", "876545678"), new CreditCard(CreditCardType.VISA, "testing", "9876545678", date, "uhgbnjuygbn", 200));

            Assert.Throws<CreditCardExpiredException>(() => _paymentManager.ValidateAndPlaceOrder(order));
        }

        [Fact]
        public void ValidateAndPlaceOrder_ThrowsCreditCardInsufficientAmountException_IfCardHasInsufficientFunds()
        {
            var basket = new Basket("igfskhbv");
            basket.Items = new List<BasketItem> { new BasketItem(1, 1, 10m) };
            var order = new Order(basket, new Contact("testing@hello.com", "876545678"), new CreditCard(CreditCardType.VISA, "testing", "9876545678", DateTime.UtcNow.AddMonths(1), "uhgbnjuygbn", 0));

            _paymentServiceMock.Setup(x => x.GetHoldOfCard(order.CreditCard)).Returns(50m);

            Assert.Throws<CreditCardInsufficientAmountException>(() => _paymentManager.ValidateAndPlaceOrder(order));
        }

        [Fact]
        public void ValidateAndPlaceOrder_ProcessesPayment_IfAllConditionsAreMet()
        {
            var basket = new Basket("igfskhbv");
            basket.Items = new List<BasketItem> { new BasketItem(1, 1, 10m) };

            var order = new Order(basket, new Contact("testing@hello.com", "876545678"), new CreditCard(CreditCardType.VISA, "testing", "9876545678", DateTime.UtcNow.AddMonths(1), "uhgbnjuygbn", 12m));

            Assert.Throws<Exception>(()=>_paymentManager.ValidateAndPlaceOrder(order));
        }
    }
}
