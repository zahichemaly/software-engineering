using AutoMapper;
using MediatR;
using NewsBoard.Business.DTOs;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        var result = await _newsRepository.Get();
        var dtos = _mapper.Map<IEnumerable<NewsDTO>>(result);
        return dtos;
    }
}
