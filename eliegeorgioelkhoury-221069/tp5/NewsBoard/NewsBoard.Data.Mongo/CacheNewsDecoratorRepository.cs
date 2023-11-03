using CacheManager.Core;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;



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

        public async Task<News> Get(string id)
        {
            string cacheKey = $"News_{id}";

            if (_cacheManager.Exists(cacheKey))
            {
                return _cacheManager.Get(cacheKey);
            }

            var news = await _newsRepository.Get(id);
            if (news != null)
            {
                _cacheManager.Add(cacheKey, news);
            }
            return news;
        }

        public async Task Update(News news)
        {
            await _newsRepository.Update(news);
        }
    }

}
