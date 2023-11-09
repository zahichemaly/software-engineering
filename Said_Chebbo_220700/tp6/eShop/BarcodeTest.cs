using System;

public class Class1
{
    [Fact]
    public void Create_Should_Return_Null_When_Value_Is_Null()
    {
        string value = null;
        var barcode = Barcode.Create(value);
        Assert.Null(barcode);
    }
}
