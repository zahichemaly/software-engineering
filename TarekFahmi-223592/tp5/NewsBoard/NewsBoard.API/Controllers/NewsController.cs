using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

namespace NewsBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _newsRepository.Get();
            if (result == null) return NotFound();
            return Ok(result);
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
            await _newsRepository.Add(model);
            return Ok(new { model.Id });
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
}
