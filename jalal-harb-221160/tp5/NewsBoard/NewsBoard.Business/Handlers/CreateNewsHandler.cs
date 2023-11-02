using MediatR;
using NewsBoard.Business.Models;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Business.Handlers
{
    public class CreateNewsHandler : IRequestHandler<CreateNewsCommand, string>
    {
        private readonly INewsRepository _newsRepository;
        public CreateNewsHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task<string> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.Add(request.News);
            return request.News.Id;
        }
    }
}
