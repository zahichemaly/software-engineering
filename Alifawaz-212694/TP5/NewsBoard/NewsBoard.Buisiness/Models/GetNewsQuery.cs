using MediatR;
using NewsBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Models
{
    public class GetNewsQuery:IRequest<IEnumerable<News>>
    {
       public DateTime? StartDate { get; set; }
       public DateTime? EndDate { get; set; }   
       public string Category { get; set; }    

    }
}
