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
    public class UpdateNewsHandler : IRequestHandler<UpdateNewsCommand, Unit>
    {
        private readonly INewsRepository _newsRepository;

        public UpdateNewsHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.Update(request.News);
            return Unit.Value;
        }
    }
}
