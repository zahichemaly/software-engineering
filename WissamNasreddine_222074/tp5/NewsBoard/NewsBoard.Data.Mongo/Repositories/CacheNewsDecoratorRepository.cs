using CacheManager.Core;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Data.Mongo.Repositories
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

        public Task Add(News news)
        {
            return _newsRepository.Add(news);
        }

        public Task Delete(string id)
        {
            return _newsRepository.Delete(id);
        }

        public async Task<News> Get(string id)
        {
            // Try to fetch the record from the cache
            var cachedNews = _cacheManager.Get(id);

            if (cachedNews != null)
            {
                return cachedNews;
            }
            else
            {
                // If not found in the cache, query MongoDB using NewsRepository
                var news = await _newsRepository.Get(id);

                if (news != null)
                {
                    // Store the record in the cache for future requests
                    _cacheManager.Add(new CacheItem<News>(id, news));
                }

                return news;
            }
        }

        public Task<IEnumerable<News>> Get()
        {
            return _newsRepository.Get();
        }

        public IEnumerable<News> GetAllNews()
        {
            return _newsRepository.GetAllNews();
        }

        public Task Update(News news)
        {
            return _newsRepository.Update(news);
        }

        // Implement other interface methods here, delegating to _newsRepository
    }

}
