using System;
using System.Linq;
using Xunit;
using eShop.Core.Entities;
using System.Collections.Generic;
using System.Collections;

namespace eShop.UnitTests
{
    public class BarcodeTest
    {

        public static IEnumerable InvalidSkuLengthData = new List<object[]> {
            new object[] { "invalid_sku" },
            new object[] { "invalid_sku_1" },
            new object[] { "invalid_sku_2" },
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
        public void Create_Should_Return_Null_When_Length_Is_Not_15(string value)
        {
            var barcode = Barcode.Create(value);
            Assert.Null(barcode);
        }

    }
    public class BarcodeTestData : TheoryData<Barcode>
    {
        public BarcodeTestData()
        {
            Add(Barcode.Create("abcdefghijk1234"));
        }

        [Theory]
        [ClassData(typeof(BarcodeTestData))]
        public void Create_Should_Return_Null_When_Length_Is_Not_15(Barcode barcode)
        {
            Assert.NotNull(barcode);
            Assert.Equal(15, barcode.Value.Length);
        }
    }



}