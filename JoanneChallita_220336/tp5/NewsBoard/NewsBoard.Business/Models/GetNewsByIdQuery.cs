using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

public class GetNewsByIdQuery : IRequest<News>
{
    public string NewsId { get; set; }
}


