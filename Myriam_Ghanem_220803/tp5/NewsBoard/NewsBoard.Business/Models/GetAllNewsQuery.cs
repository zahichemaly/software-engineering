using MediatR;
using NewsBoard.Data;
using NewsBoard.Data.Repositories;
 
public class GetAllNewsQuery : IRequest<IEnumerable<News>> { }
 
public class GetAllNewsHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
 
{
 
    private readonly INewsRepository _newsRepository;
 
    public GetAllNewsHandler(INewsRepository newsRepository)
 
    {
 
        _newsRepository = newsRepository;
 
    }
 
    public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
 
    {
 
        var result = await _newsRepository.Get();
 
        return result;
 
    }
 
}