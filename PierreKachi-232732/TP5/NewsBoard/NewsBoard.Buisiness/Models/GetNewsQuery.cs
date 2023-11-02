using MediatR;
using NewsBoard.Buisiness.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Models
{
    public class GetNewsQuery : IRequest<IEnumerable<NewsDTO>> { }

}
