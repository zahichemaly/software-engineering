using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tp4.CustomAttributes
{
    public class YearRangeAttributecs : RangeAttribute
    {
        public YearRangeAttributecs() : base(typeof(int), DateTime.Now.AddYears(-50).Year.ToString(),
DateTime.Now.AddYears(1).Year.ToString())
        { }
    }

}
