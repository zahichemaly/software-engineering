using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using NewsBoard.Business.Models;

namespace NewsBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var command = new GetNewsQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var command = new GetNewsByIdQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(command);
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
            var command = new UpdateNewsCommand()
            {
                News = model
            };
            var result = await _mediator.Send(command);
            return Ok(new { Id = result });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var command = new DeleteNewsCommand()
            {
                Id= id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
