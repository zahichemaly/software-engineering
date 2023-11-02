using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Data.Entities
{
   public class News
   {
        public News()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedDate = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string Headline { get; set; }
        public string Article { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Rating { get; set; }
        public int Views { get; set; }
   }
    
}
