using eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UnitTests
{
    public class BasketItemTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Constructor_ThrowsException_IfQuantityIsNegative(int quantity)
        {
            int catalogItemId = 1;
            decimal unitPrice = 10m;

            Assert.Throws<ArgumentOutOfRangeException>(() => new BasketItem(catalogItemId, quantity, unitPrice));
        }

        [Fact]
        public void AddQuantity_UpdatesQuantity()
        {
            var basketItem = new BasketItem(1, 1, 10m);
            int quantityToAdd = 2;

            
            basketItem.AddQuantity(quantityToAdd);

            Assert.Equal(3, basketItem.Quantity);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        public void AddQuantity_ThrowsException_IfQuantityIsNegative(int quantityToAdd)
        {
            
            var basketItem = new BasketItem(1, 1, 10m);

            Assert.Throws<ArgumentOutOfRangeException>(() => basketItem.AddQuantity(quantityToAdd));
        }

        [Fact]
        public void SetQuantity_UpdatesQuantity()
        {
            
            var basketItem = new BasketItem(1, 1, 10m);
            int newQuantity = 5;

            basketItem.SetQuantity(newQuantity);

            Assert.Equal(newQuantity, basketItem.Quantity);
        }

        [Fact]
        public void GetTotalPrice_ReturnsCorrectResult()
        {
            var basketItem = new BasketItem(1, 2, 10m);

            var totalPrice = basketItem.GetTotalPrice();

            Assert.Equal(20m, totalPrice);
        }
    }
}
