using eShop.Core.Entities;
using eShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IRepository<Basket> _basketRepository;

        public BasketController(IRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _basketRepository.GetAllAsync();
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Basket model)
        {
            var result = await _basketRepository.CreateAsync(model);
            return Ok(result);
        }
    }
}
