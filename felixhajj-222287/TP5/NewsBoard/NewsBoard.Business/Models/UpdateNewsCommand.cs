using MediatR;
using NewsBoard.Data.Entities;

namespace NewsBoard.Business.Models
{
    public class UpdateNewsCommand : IRequest<string>
    {
        public News News { get; set; }
    }
}
