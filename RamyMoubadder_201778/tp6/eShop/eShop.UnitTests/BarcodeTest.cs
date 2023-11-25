using eShop.Core.Entities;
using System;
using System.Collections.Generic;
using Xunit;

public class BarcodeTestData : TheoryData<string>
{
    public BarcodeTestData()
    {
        Add("............."); 
    }
}

public class BarcodeTest
{
    public static IEnumerable<object[]> InvalidSkuLengthData()
    {
        yield return new object[] { "invalid_sku" };
        yield return new object[] { "invalid_sku-1" };
        yield return new object[] { "invalid_sku-2" };
    }

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
    public void Create_InvalidSkuLengthData(string lengthdata)
    {
        var barcode = Barcode.Create(lengthdata);
        Assert.Null(barcode);
    }

    [Theory]
    [ClassData(typeof(BarcodeTestData))]
    public void Is_Barcode_Created_When_Length_Is_15(string value)
    {
        var barcode = Barcode.Create(value);
        Assert.NotNull(barcode);
    }
}
