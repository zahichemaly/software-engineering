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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var result = await _basketRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Basket model)
        {
            var result = await _basketRepository.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddItemToBasket([FromRoute] string id, [FromBody] BasketItem basketItem)
        {
            // sanity check
            if (basketItem == null) return BadRequest();

            // fetch basket
            var basket = await _basketRepository.GetByIdAsync(id);
            if (basket == null) return NotFound();

            // add item to basket
            basket.AddItem(basketItem.CatalogItemId, basketItem.UnitPrice, basketItem.Quantity);

            // replace new basket
            await _basketRepository.UpdateAsync(basket);

            return Ok(basket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _basketRepository.GetByIdAsync(id);
            if (result == null) return NotFound();
            await _basketRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
