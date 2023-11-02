using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

public class GetAllNewsQuery : IRequest<IEnumerable<NewsDTO>> { }


