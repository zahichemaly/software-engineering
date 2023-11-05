using NewsBoard.Data.Repositories;
using NewsBoard.Data.Entities;
using CacheManager.Core;

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
            // Try to fetch the record from the cache
            var cachedNews = _cacheManager.Get(id);

            if (cachedNews != null)
            {
                return cachedNews;
            }
            else
            {
                // Query MongoDB using the underlying repository
                var news = await _newsRepository.Get(id);

                if (news != null)
                {
                    // Store the record in the cache
                    _cacheManager.AddOrUpdate(id, news);
                }

                return news;
            }
        }

        // Implement other methods of INewsRepository without decorating them
        public async Task Add(News news)
        {
            await _newsRepository.Add(news);
        }

        public async Task Delete(string id)
        {
            await _newsRepository.Delete(id);
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
