namespace eShop.Core.Entities
{
    public class Barcode
    {
        public static int DefaultLength = 15;
        public string Value { get; private set; }

        private Barcode(string value)
        {
            Value = value;
        }

        public static Barcode Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            if (value.Length != DefaultLength)
            {
                return null;
            }

            return new Barcode(value);
        }
    }
}
