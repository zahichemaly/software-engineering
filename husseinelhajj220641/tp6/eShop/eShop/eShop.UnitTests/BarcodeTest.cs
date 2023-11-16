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
        public static IEnumerable<object[]> InvalidSkuLengthData = new List<object[]>
        {
            new object[] { "invalid_sku" },
            new object[] { "invalid_sku_1" },
            new object[] { "invalid_sku_2" }
        };

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Create_Should_Return_Null_When_Value_Is_NullOrEmpty(string value)
        {
            var barcode = Barcode.Create(value);
            Assert.Null(barcode);
        }

        [Theory]
        [MemberData(nameof(InvalidSkuLengthData))]
        public void Create_Should_Return_Null_When_Sku_Length_Is_Invalid(string value)
        {
            var barcode = Barcode.Create(value);
            Assert.Null(barcode);
        }

        [Theory]
        [ClassData(typeof(BarcodeTestData))]
        public void Should_Create_Barcode_When_Sku_Length_Is_15(Barcode barcode)
        {
            Assert.NotNull(barcode);
        }
    }
}
