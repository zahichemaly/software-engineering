using System.Text.Json.Serialization;

namespace eShop.Core.Entities
{
    public class Basket : BaseEntity
    {
        public string BuyerId { get; private set; }
        public List<BasketItem> Items { get; set; }

        // Rest of the class remains unchanged...

        // Add a constructor that allows setting the BuyerId during object creation
        public Basket(string buyerId, List<BasketItem> items = null) : base()
        {
            BuyerId = buyerId;
            Items = items ?? new List<BasketItem>();
        }

        /// <summary>
        /// Adds a new item to the basket in case it does not exist.
        /// Otherwise, increments the quantity of the existing item in the basket.
        /// </summary>
        /// <param name="catalogItemId">The catalog item Id which is unique per item.</param>
        /// <param name="unitPrice">Price of a single item.</param>
        /// <param name="quantity">Quantity of items.</param>
        public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                Items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.First(i => i.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        /// <summary>
        /// Clears all items with 0 quantity from the basket.
        /// </summary>
        public void RemoveEmptyItems()
        {
            Items.RemoveAll(i => i.Quantity == 0);
        }

        /// <summary>
        /// Updates the buyer Id.
        /// </summary>
        /// <param name="buyerId"></param>
        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }

        /// <summary>
        /// Total price of the basket.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.GetTotalPrice());
        }
    }
}
