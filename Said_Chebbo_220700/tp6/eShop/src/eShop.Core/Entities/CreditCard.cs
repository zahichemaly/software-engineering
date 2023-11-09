namespace eShop.Core.Entities
{
    public class CreditCard
    {
        public CreditCardType Type { get; set; }
        public string CardHolderName { get; set; }
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public string SecurityCode { get; set; }
    }

    public enum CreditCardType
    {
        VISA,
        MASTERCARD
    }
}
