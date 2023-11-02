using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Models
{
    public class DeleteNewsCommand : IRequest<Unit>
    {
        public string Id { get; set; }
    }
}
