using AutoMapper;
using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Handlers
{
    public class GetNewsHandler : IRequestHandler<GetNewsQuery, IEnumerable<NewsDTO>>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public GetNewsHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDTO>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Get();
            var dtos = _mapper.Map<IEnumerable<NewsDTO>>(news);
            return dtos;
        }
    }
}
