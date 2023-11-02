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
    

    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, string>
    {
        private readonly INewsRepository _newsRepository;

        public UpdateNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<string> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.Update(request.News);
            return request.News.Id;
        }
    }

}
