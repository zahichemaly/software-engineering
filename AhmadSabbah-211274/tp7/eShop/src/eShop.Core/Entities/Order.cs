namespace eShop.Core.Entities
{
    public class Order
    {
        public basket Basket { get; private set; }
        public Contact Contact { get; set; }
        public CreditCard CreditCard { get; set; }

        public Order(basket basket, Contact contact, CreditCard creditCard)
        {
            Basket = basket;
            Contact = contact;
            CreditCard = creditCard;
        }
    }
}
