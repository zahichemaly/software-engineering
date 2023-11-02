using MediatR;
using NewsBoard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Models
{
    public class UpdateNewsCommand : IRequest<string>
    {
        public News News { get; set; }
    }
}
