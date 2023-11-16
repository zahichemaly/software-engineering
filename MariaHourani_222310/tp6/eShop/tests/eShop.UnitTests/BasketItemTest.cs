using System;
using System.Linq;
using Xunit;
using eShop.Core.Entities;
using System.Collections.Generic;
using System.Collections;

namespace eShop.UnitTests
{
    public class BasketItemTest
    {
        [Fact]
        public void AddQuantity_ShouldSucceedIfQuantityIsNotNegative()
        {
            var basketItem = new BasketItem(1, 10, 10.0m);

            basketItem.AddQuantity(5);

            Assert.Equal(15, basketItem.Quantity);
        }
        [Fact]
        public void SetQuantity_ShouldSucceedIfQuantityIsNotNegative()
        {
            var basketItem = new BasketItem(1, 10, 10.0m);

            basketItem.SetQuantity(5);

            Assert.Equal(5, basketItem.Quantity);
        }

        [Fact]
        public void AddQuantity_ShouldFailIfQuantityIsNegative()
        {
            var basketItem = new BasketItem(1, 10, 10.0m);

            Assert.Throws<ArgumentOutOfRangeException>(() => basketItem.AddQuantity(-5));
        }
        [Fact]
        public void CanCreateNewBasketItemWithValidValues()
        {
            int catalogItemId = 1;
            int quantity = 2;
            decimal unitPrice = 10.00m;

            var basketItem = new BasketItem(catalogItemId, quantity, unitPrice);

            Assert.Equal(catalogItemId, basketItem.CatalogItemId);
            Assert.Equal(quantity, basketItem.Quantity);
            Assert.Equal(unitPrice, basketItem.UnitPrice);
        }
        [Fact]
        public void ThrowsArgumentOutOfRangeExceptionWhenQuantityIsNegative()
        {
            var basketItem = new BasketItem(1, 2, 10.00m);
            Assert.Throws<ArgumentOutOfRangeException>(() => basketItem.SetQuantity(-2));
        }

    }
}

