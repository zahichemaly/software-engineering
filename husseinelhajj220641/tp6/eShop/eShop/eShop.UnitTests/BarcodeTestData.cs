using eShop.Core.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UnitTests
{
    public class BarcodeTestData : TheoryData<Barcode>
    {
        public BarcodeTestData()
        {
            Add(Barcode.Create("hjuytvbeasdgted"));
        }
    }
}
