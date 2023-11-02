using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;

namespace NewsBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var result = await _mediator.Send(new GetAllNewsQuery());
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetNewsByIdQuery { NewsId = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] News model)
        {
            var command = new CreateNewsCommand { News = model };
            var result = await _mediator.Send(command);
            return Ok(new { Id = result });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] News model)
        {
            var command = new UpdateNewsCommand { News = model };
            await _mediator.Send(command);
            return Ok(new { model.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var command = new DeleteNewsCommand { NewsId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
