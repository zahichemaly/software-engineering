using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.DTOs
{
    public class NewsDTO
    {
        public string Id { get; set; }
        public string Headline { get; set; }
        public string Article { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Rating { get; set; }
        public int Views { get; set; }
        public bool IsTrending { get; set; }
    }
}
