using AutoMapper;
using MediatR;
using NewsBoard.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Models
{
    public class GetAllNewsQuery : IRequest<IEnumerable<NewsDTO>>
    {
        public IMapper Mapper { get; }

        public GetAllNewsQuery(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
