//using eShop.Core.Entities;
//using eShop.Core.Exceptions;
//using eShop.Core.Interfaces;
//using eShop.Core.Managers;
//using Moq;

//namespace eShop.UnitTests { 
//    public class PaymentManagerTest { 
//        private readonly Mock<IPaymentService> _paymentServiceMock;
//        private readonly Mock<IAppLogger<PaymentManager>> _loggerMock;


//        public PaymentManagerTest()
//    {
//        _paymentServiceMock = new Mock<IPaymentService>();
//        _loggerMock = new Mock<IAppLogger<PaymentManager>>();
//    }
        

//    [Fact]
//    public void ValidateAndPlaceOrder_Should_Throw_EmptyBasketOnCheckoutException_When_Basket_Is_Empty()
//    {
        
       
//    }

//    [Fact]
//    public void ValidateAndPlaceOrder_Should_Throw_CreditCardExpiredException_When_CreditCard_Is_Expired()
//    {
//    }

//    [Fact]
//    public void ValidateAndPlaceOrder_Should_Throw_CreditCardInsufficientAmountException_When_CreditCard_Has_Insufficient_Amount()
//    {
        
     
//    }

//    [Fact]
//    public void ValidateAndPlaceOrder_Should_Process_Payment_And_Return_Remaining_Amount_When_Order_Is_Valid()
//    {
      
//    }
//}