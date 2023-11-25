using eShop.Core.Entities;

namespace eShop.UnitTests
{
    public class BarcodeTestData : TheoryData<Barcode>
    {
        public BarcodeTestData()
        {
            Barcode b1 = Barcode.Create("121212121212121");
            Add(b1);
        }
    }
    public class BarcodeTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Create_Should_Return_Null_When_Value_Is_NullOrEmpty(string value)
        {
            var barcode = Barcode.Create(value);
            Assert.Null(barcode);
        }
        public static IEnumerable<object[]> InvalidSkuLengthData = new List<object[]>
{
            new object[] { "invalid_sku" },
            new object[] { "invalid_sku_1" },
            new object[] { "invalid_sku_2" }
            };
        [Theory]
        [MemberData(nameof(InvalidSkuLengthData))]
        public void Create_Should_Return_Null_When_Value_Is_Not_15(string value)
        {
            var barcode = Barcode.Create(value);
            Assert.Null(barcode);
        }
        [Theory]
        [ClassData(typeof(BarcodeTestData))]
        public void Create_Should_Return_Barcode_When_Value_Is_15_Characters(Barcode barcode)
        {   
            Assert.NotNull(barcode);
        }

    }


}
