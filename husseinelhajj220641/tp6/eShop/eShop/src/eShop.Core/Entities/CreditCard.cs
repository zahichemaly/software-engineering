namespace eShop.Core.Entities
{
    public class CreditCard
    {
        public CreditCardType Type { get; set; }
        public string CardHolderName { get; set; }
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        public string SecurityCode { get; set; }
        public decimal Fund { get; set; }

        public CreditCard(CreditCardType type, string cardHolderName, string number, DateTime expiration, string securityCode, decimal fund)
        {
            Type = type;
            CardHolderName = cardHolderName;
            Number = number;
            Expiration = expiration;
            SecurityCode = securityCode;
            Fund = fund;
        }
    }

    public enum CreditCardType
    {
        VISA,
        MASTERCARD
    }
}
