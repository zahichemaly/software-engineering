using eShop.Core.Entities;

namespace eShop.UnitTests
{

    public class BasketItemTest
    {
        [Fact]
        public void AddQuantity_Should_Increase_Quantity()
        {
            var basketItem = new BasketItem(1, 1, 10m);
            basketItem.AddQuantity(1);
            Assert.Equal(2, basketItem.Quantity);
        }

        [Fact]
        public void AddQuantity_Should_Throw_Exception_When_Negative()
        {
            var basketItem = new BasketItem(1, 1, 10m);

            Assert.Throws<ArgumentOutOfRangeException>(() => basketItem.AddQuantity(-1));
        }

        [Fact]
        public void SetQuantity_Should_Change_Quantity()
        {
            var basketItem = new BasketItem(1, 1, 10m);

            basketItem.SetQuantity(2);

            Assert.Equal(2, basketItem.Quantity);
        }

        [Fact]
        public void SetQuantity_Should_Throw_Exception_When_Negative()
        {
            var basketItem = new BasketItem(1, 1, 10m);

            Assert.Throws<ArgumentOutOfRangeException>(() => basketItem.SetQuantity(-1));
        }

        [Fact]
        public void GetTotalPrice_Should_Return_Correct_Total()
        {
            var basketItem = new BasketItem(1, 2, 10m);

            var total = basketItem.GetTotalPrice();

            Assert.Equal(20m, total);
        }
    }
}


