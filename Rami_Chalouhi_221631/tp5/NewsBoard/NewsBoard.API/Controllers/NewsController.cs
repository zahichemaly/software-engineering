using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Business.DTOs;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using AutoMapper;
using CacheManager.Core;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsRepository _newsRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ICacheManager<News> _cacheManager;

    public NewsController(INewsRepository newsRepository, IMediator mediator, IMapper mapper, ICacheManager<News> cacheManager)
    {
        _newsRepository = newsRepository;
        _mediator = mediator;
        _mapper = mapper;
        _cacheManager = cacheManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _newsRepository.Get();
        var dtos = _mapper.Map<IEnumerable<NewsDTO>>(result);

        if (dtos == null) return NotFound();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var result = await _newsRepository.Get(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] News model)
    {
        var command = new CreateNewsCommand()
        {
            News = model
        };
        var result = await _mediator.Send(command);
        return Ok(new { Id = result });
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] News model)
    {
        await _newsRepository.Update(model);
        return Ok(new { model.Id });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _newsRepository.Delete(id);
        return NoContent();
    }
    [HttpDelete("cache")]
    public IActionResult ClearCache()
    {
         
        _cacheManager.Clear(); 
        return Ok("Cache cleared,now the data will be fetched from the database!!");
    }

}