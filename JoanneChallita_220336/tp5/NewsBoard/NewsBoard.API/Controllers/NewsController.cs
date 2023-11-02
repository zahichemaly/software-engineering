using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsRepository _newsRepository;
    private readonly IMediator _mediator;

    public NewsController(INewsRepository newsRepository, IMediator mediator)
    {
        _newsRepository = newsRepository;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _newsRepository.Get();
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var result = await _newsRepository.Get(id);
        if (result == null)
            return NotFound();
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
}
