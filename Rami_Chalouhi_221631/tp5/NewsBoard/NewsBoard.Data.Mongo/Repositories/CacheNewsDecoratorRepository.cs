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

        public async Task<News> Get(string id)
        {

            var cachedNews = _cacheManager.Get(id);
            if (cachedNews != null)
            {
                return cachedNews;
            }


            var news = await _newsRepository.Get(id);

            if (news != null)
            {
                _cacheManager.Add(new CacheItem<News>(id, news));
            }

            return news;
        }


        public async Task<IEnumerable<News>> Get()
        {
            return await _newsRepository.Get();
        }


        public async Task Delete(string id)
        {
            await _newsRepository.Delete(id);
        }

        public async Task Add(News news)
        {
            await _newsRepository.Add(news);
        }

        public async Task Update(News news)
        {
            await _newsRepository.Update(news);
        }

    }
}