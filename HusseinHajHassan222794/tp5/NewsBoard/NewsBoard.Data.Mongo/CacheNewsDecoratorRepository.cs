using CacheManager.Core;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Mongo.Repositories;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Data.Mongo
{
    public class CacheNewsDecoratorRepository : INewsRepository
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICacheManager<News> _cacheManager;


        public CacheNewsDecoratorRepository(INewsRepository newsRepository, ICacheManager<News> cacheManager)
        {
            _newsRepository = newsRepository;
            _cacheManager = cacheManager;
        }

        public async Task<News> Get(string id)
        {
            var cacheKey = $"News_{id}";

            var cachedNews = _cacheManager.Get(cacheKey);

            if (cachedNews != null)
            {
                return cachedNews;
            }

            var news = await _newsRepository.Get(id);

            if (news != null)
            {
                _cacheManager.Add(cacheKey, news);
            }

            return news;
        }

        public async Task Add(News news)
        {
            await _newsRepository.Add(news);
        }

        public async Task Delete(string id)
        {
            await _newsRepository.Delete(id);
            _cacheManager.Remove("AllNews");
        }

        public async Task<IEnumerable<News>> Get()
        {
            return await _newsRepository.Get();
        }
        public async Task Update(News news)
        {
            await _newsRepository.Update(news);
        }
    }
}
