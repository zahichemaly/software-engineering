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
    public class GetAllNewsHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<NewsDTO>>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public GetAllNewsHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDTO>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            // Retrieve news from the repository
            var news = _newsRepository.GetAllNews();

            // Map News objects to NewsDTO using AutoMapper
            var dtos = _mapper.Map<IEnumerable<NewsDTO>>(news);

            return dtos;
        }
    }
    //{
    //    private readonly INewsRepository _newsRepository;

    //    public GetAllNewsHandler(INewsRepository newsRepository)
    //    {
    //        _newsRepository = newsRepository;
    //    }

    //    public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
    //    {
    //        // Implement the logic to retrieve and return all news articles.
    //        return _newsRepository.GetAllNews();
    //    }
    //}


}
