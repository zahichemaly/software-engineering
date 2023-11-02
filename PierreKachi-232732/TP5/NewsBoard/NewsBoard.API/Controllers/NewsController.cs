using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Buisiness.Handlers;
using NewsBoard.Buisiness.Models;
using NewsBoard.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var result = await _mediator.Send(new GetNewsQuery());
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetNewsByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] News model)
        {
            await _mediator.Send(new UpdateNewsCommand { News = model });
            return Ok(new { model.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _mediator.Send(new DeleteNewsCommand { Id = id });
            return NoContent();
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
    }
}
