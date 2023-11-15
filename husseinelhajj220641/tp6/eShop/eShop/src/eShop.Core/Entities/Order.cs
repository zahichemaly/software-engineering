namespace eShop.Core.Entities
{
    public class Order
    {
        public Basket Basket { get; set; }
        public Contact Contact { get; set; }
        public CreditCard CreditCard { get; set; }

        public Order(Basket basket, Contact contact, CreditCard creditCard)
        {
            Basket = basket;
            Contact = contact;
            CreditCard = creditCard;
        }
    }
}
