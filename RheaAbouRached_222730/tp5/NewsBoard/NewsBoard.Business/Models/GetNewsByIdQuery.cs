using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Data.Repositories;

public class GetNewsByIdQuery : IRequest<NewsDTO>
{
    public string NewsId { get; set; }
}