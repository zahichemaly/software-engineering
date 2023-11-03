using MediatR;
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
    public class GetNewsHandler :IRequestHandler<GetNewsQuery, IEnumerable<News>>
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
    }
}
