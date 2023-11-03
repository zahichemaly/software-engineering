using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Buisiness.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

namespace NewsBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly IMediator mediator;
        public NewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await mediator.Send(new GetNewsQuery());

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var query = new GetNewsByIdQuery { NewsId = id };

            var result = await mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] News model)
        {
            var command = new CreateNewsCommand()
            {
                News = model
            };
            var result = await mediator.Send(command);
            return Ok(new { Id = result });

        }
        public async Task<IActionResult> UpdateNews(string id, [FromBody] News news)
        {
            if (id != news.Id)
                return BadRequest();

            var command = new UpdateNewsCommand { News = news };
            await mediator.Send(command);

            return NoContent();
            /*        [HttpDelete("{id}")]
                    public async Task<IActionResult> Delete([FromRoute] string id)
                    {
                        await _newsRepository.Delete(id);
                        return NoContent();
                    }*/
        }
    }
}
