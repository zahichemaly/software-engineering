using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Models
{
    public class CreateNewsCommand : IRequest<string>
    {
        public News News { get; set; }
    }
}
