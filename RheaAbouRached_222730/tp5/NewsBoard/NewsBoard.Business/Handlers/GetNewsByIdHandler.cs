using AutoMapper;
using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Business.Models;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Handlers
{
    public class GetNewsByIdHandler : IRequestHandler<GetNewsByIdQuery, NewsDTO>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public GetNewsByIdHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<NewsDTO> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.Get(request.NewsId);

            var newsDTO = _mapper.Map<NewsDTO>(news);

            return newsDTO;
        }
    }
}
