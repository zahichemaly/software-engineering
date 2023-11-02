
using MediatR;
using NewsBoard.Business.Models;
using NewsBoard.Data;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace NewsBoard.Business.Handlers
{

    public class GetAllNewsHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>

    {

        private readonly INewsRepository _newsRepository;

        public GetAllNewsHandler(INewsRepository newsRepository)

        {

            _newsRepository = newsRepository;

        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)

        {

            var result = await _newsRepository.Get();

            return result;

        }

    }

}
