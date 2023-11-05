﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoard.Business.Models;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System.Threading.Tasks;
using CacheManager.Core;

namespace NewsBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMediator _mediator;
        private readonly ICacheManager<News> _cacheManager;
        public NewsController(INewsRepository newsRepository, IMediator mediator, ICacheManager<News> cacheManager)
        {
            _newsRepository = newsRepository;
            _mediator = mediator;
            _cacheManager = cacheManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Use MediatR to retrieve all news
            var query = new GetAllNewsQuery();
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            // Use MediatR to retrieve news by ID
            var query = new GetNewsByIdQuery { NewsId = id };
            var result = await _mediator.Send(query);

            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] News model)
        {
            // Use MediatR to create a news article
            var command = new CreateNewsCommand
            {
                News = model
            };
            var result = await _mediator.Send(command);
            return Ok(new { Id = result });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] News model)
        {
            // Use MediatR to update a news article
            var command = new UpdateNewsCommand
            {
                News = model
            };
            await _mediator.Send(command);

            return Ok(new { model.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            // Use MediatR to delete a news article
            var command = new DeleteNewsCommand
            {
                NewsId = id
            };
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/News/ClearCache
        [HttpDelete("ClearCache")]
        public IActionResult ClearCache()
        {
            try
            {
                // Clear the entire cache
                _cacheManager.Clear();

                return Ok("Cache cleared successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during cache clearing
                return StatusCode(500, "Failed to clear the cache: " + ex.Message);
            }
        }
    }
}
