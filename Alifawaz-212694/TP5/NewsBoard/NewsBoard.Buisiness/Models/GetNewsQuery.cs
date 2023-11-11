using MediatR;
using NewsBoard.Buisiness.DTOs;
using NewsBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Models
{
    public class GetNewsQuery:IRequest<IEnumerable<NewsDTO>>
    {
       

    }
    
}
