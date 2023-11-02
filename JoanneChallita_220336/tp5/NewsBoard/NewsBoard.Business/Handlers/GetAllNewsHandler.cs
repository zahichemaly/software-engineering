using AutoMapper;
using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Data.Repositories;

public class GetAllNewsHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<NewsDTO>>
{
    private readonly INewsRepository _newsRepository;
    private readonly IMapper _mapper;

    public GetAllNewsHandler(INewsRepository newsRepository, IMapper mapper)
    {
        _newsRepository = newsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NewsDTO>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
    {
        // Retrieve news from the repository
        var news = _newsRepository.Get();

        // Map News objects to NewsDTO using AutoMapper
        var dtos = _mapper.Map<IEnumerable<NewsDTO>>(news);

        return dtos;
    }
}