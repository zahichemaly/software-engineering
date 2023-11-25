using eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UnitTests
{
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
        public void BarcodeLengthIsNot15(string sku)
        {
            var barcode = Barcode.Create(sku);

            // Assert that the barcode is not valid.
            Assert.Null(barcode);
        }

    }
    public class BarcodeTestData : TheoryData<Barcode>
    {
        public BarcodeTestData()
        {
            Add(Barcode.Create("123456789123456"));
        }

        [Theory]
        [ClassData(typeof(BarcodeTestData))]
        public void BarcodeLenghtExactly15(Barcode barcode)
        {
            Assert.NotNull(barcode);
            Assert.Equal(15, barcode.Value.Length);
        }
    }
}
