using AutoMapper;
using MediatR;
using Microsoft.Win32;
using NewsBoard.Buisiness.DTOs;
using NewsBoard.Buisiness.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Handlers
{

    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, IEnumerable<NewsDTO>>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public GetNewsQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDTO>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.Get();
            var dtos = _mapper.Map<IEnumerable<NewsDTO>>(result);
            return dtos;
        }
    }
}




