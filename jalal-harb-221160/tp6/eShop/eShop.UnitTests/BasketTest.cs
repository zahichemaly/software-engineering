using eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UnitTests
{
    public class BasketTest
    {
        [Fact]
        public void AddItem_AddsNewItem_WhenNotPresent()
        {
            var basket = new Basket("buyer123");
            int catalogItemId = 1;
            decimal unitPrice = 10m;
            int quantity = 2;

            basket.AddItem(catalogItemId, unitPrice, quantity);

            Assert.Single(basket.Items);
            Assert.Equal(quantity, basket.Items.First().Quantity);
        }

        [Fact]
        public void AddItem_IncrementsQuantity_WhenItemExists()
        {
            var basket = new Basket("buyer123");
            int catalogItemId = 1;
            decimal unitPrice = 10m;
            basket.AddItem(catalogItemId, unitPrice, 1);

            basket.AddItem(catalogItemId, unitPrice, 2);

            Assert.Single(basket.Items);
            Assert.Equal(3, basket.Items.First().Quantity);
        }

        [Fact]
        public void RemoveEmptyItems_RemovesItems_WithZeroQuantity()
        {
            var basket = new Basket("buyer123");
            basket.Items.Add(new BasketItem(1, 0, 10m));

            basket.RemoveEmptyItems();

            Assert.Empty(basket.Items);
        }

        [Fact]
        public void SetNewBuyerId_UpdatesBuyerIdCorrectly()
        {
            var basket = new Basket("buyer123");
            string newBuyerId = "buyer456";

            basket.SetNewBuyerId(newBuyerId);

            Assert.Equal(newBuyerId, basket.BuyerId);
        }

        [Fact]
        public void GetTotalPrice_CalculatesCorrectTotalPrice()
        {
            var basket = new Basket("buyer123");
            basket.AddItem(1, 10m, 1);
            basket.AddItem(2, 20m, 2);

            decimal totalPrice = basket.GetTotalPrice();

            Assert.Equal(50m, totalPrice);
        }
    }
}
