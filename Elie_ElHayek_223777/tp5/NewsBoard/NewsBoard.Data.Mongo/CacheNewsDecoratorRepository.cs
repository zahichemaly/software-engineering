using System;
using CacheManager.Core;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

namespace NewsBoard.Data.Mongo
{
    public class CacheNewsDecoratorRepository : INewsRepository
    {
        private readonly ICacheManager<News> _cacheManager;
        private readonly ICacheManager<IEnumerable<News>> _cacheManagerForList;
        private readonly INewsRepository _newsRepository;
        private readonly string allNewsCacheKey = "all_news";

        public CacheNewsDecoratorRepository(INewsRepository newsRepository, ICacheManager<News> cacheManager, ICacheManager<IEnumerable<News>> cacheManagerForList)
        {
            _newsRepository = newsRepository;
            _cacheManager = cacheManager;
            _cacheManagerForList = cacheManagerForList;
        }

        /* public async Task<News> Get(string id)
           {
                News news = _cacheManager.Get(id);
                if (news == null)
                {
                    news = await _newsRepository.Get(id);
                    if (news != null)
                    {
                     _cacheManager.Put(id, news);
                    }
                }
                return news;
            } */

        public async Task<News> Get(string id)
        {
            var cacheItem = _cacheManager.GetCacheItem(id);
            if (cacheItem == null)
            {
                var news = await _newsRepository.Get(id);
                if (news != null)
                {
                    _cacheManager.Add(new CacheItem<News>(id, news, ExpirationMode.Absolute, TimeSpan.FromHours(24)));
                }
                return news;
            }
            return cacheItem.Value;
        }

        /* public async Task<News> Get(string id)
        {
            var news = await _newsRepository.Get(id);
            _cacheManager.AddOrUpdate(id, news, updateValue: existingValue => news);
            return news;
        }*/

        public async Task<IEnumerable<News>> Get()
        {
            var cachedNews = _cacheManagerForList.Get(allNewsCacheKey);
            if (cachedNews == null)
            {
                var newsCollection = await _newsRepository.Get();
                _cacheManagerForList.Add(new CacheItem<IEnumerable<News>>(allNewsCacheKey, newsCollection, ExpirationMode.Absolute, TimeSpan.FromHours(24)));
                return newsCollection;
            }
            return cachedNews;
        }

        public async Task Delete(string id)
        {
            await _newsRepository.Delete(id);
            _cacheManager.Remove(id);
            _cacheManager.Remove(allNewsCacheKey);
        }

        public async Task Add(News news)
        {
            await _newsRepository.Add(news);
            _cacheManager.Remove(allNewsCacheKey);
        }

        public async Task Update(News news)
        {
            await _newsRepository.Update(news);
            _cacheManager.Put(new CacheItem<News>(news.Id, news, ExpirationMode.Absolute, TimeSpan.FromHours(24)));
            _cacheManager.Remove(allNewsCacheKey);
        }


        public IEnumerable<News> GetAllNews()
        {
            return _newsRepository.GetAllNews();
        }

    }
}
