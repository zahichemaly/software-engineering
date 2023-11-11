using MediatR;
using NewsBoard.Data;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Models
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public string NewsId { get; set; }
    }
}