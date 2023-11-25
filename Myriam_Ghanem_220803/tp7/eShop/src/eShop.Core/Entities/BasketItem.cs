using Ardalis.GuardClauses;

namespace eShop.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public int BasketId { get; private set; }

        public BasketItem(int catalogItemId, int quantity, decimal unitPrice): base()
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        /// <summary>
        /// Increments the quantity only if its not negative.
        /// </summary>
        /// <param name="quantity"></param>
        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return UnitPrice * Quantity;
        }
    }
}
