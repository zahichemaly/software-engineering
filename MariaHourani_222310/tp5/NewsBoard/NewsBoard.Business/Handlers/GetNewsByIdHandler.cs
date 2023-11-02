using MediatR;
using NewsBoard.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Handlers
{
    public class GetNewsByIdHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly INewsRepository _newsRepository;

        public GetNewsByIdHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _newsRepository.Get(request.NewsId);
        }
    }
}
