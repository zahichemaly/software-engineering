using MediatR;
using NewsBoard.Data.Repositories;
using NewsBoard.Buisiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Buisiness.Handlers
{
    public class DeleteNewsHandler : IRequestHandler<DeleteNewsCommand, Unit>
    {
        private readonly INewsRepository _newsRepository;

        public DeleteNewsHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.Delete(request.NewsId);
            return Unit.Value;
        }
    }
}
