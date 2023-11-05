using CacheManager.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Business.Models;

namespace NewsBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICacheManager<News> _cacheManager;

        public NewsController(IMediator mediator, ICacheManager<News> cacheManager)
        {
            _mediator = mediator;
            _cacheManager = cacheManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetNewsQuery();
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetNewsByIdQuery { NewsId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

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
            var result = await _mediator.Send(command);

            return Ok(new { Id = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteNewsCommand { NewsId = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("cache")]
        public IActionResult ClearCache()
        {
            _cacheManager.Clear();
            return NoContent();
        }
    }

  
}