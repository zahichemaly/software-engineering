using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

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
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            var query = new GetNewsQuery();
            var news = await _mediator.Send(query);
            return Ok(news);
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
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNewsById(string id)
        {
            var query = new GetNewsByIdQuery { NewsId = id };
            var news = await _mediator.Send(query);

            if (news == null)
                return NotFound();

            return Ok(news);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(string id, [FromBody] News news)
        {
            if (id != news.Id)
                return BadRequest();

            var command = new UpdateNewsCommand { News = news };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(string id)
        {
            var command = new DeleteNewsCommand { NewsId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
