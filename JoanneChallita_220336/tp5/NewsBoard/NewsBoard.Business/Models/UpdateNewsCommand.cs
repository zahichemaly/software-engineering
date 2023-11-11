using MediatR;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

public class UpdateNewsCommand : IRequest<string>
{
    public News UpdatedNews { get; set; }
}

