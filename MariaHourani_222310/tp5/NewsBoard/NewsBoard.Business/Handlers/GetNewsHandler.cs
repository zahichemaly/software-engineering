using AutoMapper;
using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Business.Models;
using System.Threading;
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
            var result = await _newsRepository.Get();
            var dtos = _mapper.Map<IEnumerable<NewsDTO>>(result);
            return dtos;
        }
    }

}

   /*public class GetNewsHandler : IRequestHandler<GetNewsQuery, IEnumerable<News>>
    {
        private readonly INewsRepository _newsRepository;

        public GetNewsHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<News>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            return await _newsRepository.Get();
        }
    }*/
