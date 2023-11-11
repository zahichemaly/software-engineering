using NewsBoard.Business.DTOs;
using NewsBoard.Business.Models;

namespace NewsBoard.Business.Handlers
{
    public interface IGetAllNewsHandler
    {
        Task<IEnumerable<NewsDTO>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken);
    }
}