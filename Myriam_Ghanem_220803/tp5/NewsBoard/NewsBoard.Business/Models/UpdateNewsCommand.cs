using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Models
{
    public class UpdateNewsCommand : IRequest<string>
    {
        public News UpdatedNews { get; set; }
    }
}
