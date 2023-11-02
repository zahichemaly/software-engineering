using MediatR;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewsBoard.Business.Models
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public string NewsId { get; set; }
    }

    
}
