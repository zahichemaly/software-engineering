using MediatR;
using NewsBoard.Business.Models;
using NewsBoard.Data.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NewsBoard.Business.Handlers
{
    public class DeleteNewsHandler : IRequestHandler<DeleteNewsCommand, string>
    {
        private readonly INewsRepository _newsRepository;

        public DeleteNewsHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<string> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.Delete(request.NewsId);
            return request.NewsId;
        }
    }
}