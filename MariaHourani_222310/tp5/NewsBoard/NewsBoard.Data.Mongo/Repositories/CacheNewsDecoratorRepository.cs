/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using CacheManager.Core;
public class CacheNewsDecoratorRepository : INewsRepository
{
    private readonly ICacheManager<News> _cacheManager;
    private readonly INewsRepository _newsRepository;

    public CacheNewsDecoratorRepository(INewsRepository newsRepository, ICacheManager<News> cacheManager)
    {
        _newsRepository = newsRepository;
        _cacheManager = cacheManager;
    }
    public async Task Update(News news)
    {
        await _newsRepository.Update(news);
        await _cacheManager.RemoveAsync(news.Id);
    }
    public async Task Delete(string id)
    {
        await _newsRepository.Delete(id);
        await _cacheManager.RemoveAsync(id);
    }

    public async Task<News> Get(string id)
    {
        var cachedNews = await _cacheManager.GetAsync(id);

        if (cachedNews != null)
        {
            return cachedNews;
        }
        else
        {
            var news = await _newsRepository.Get(id);

            if (news != null)
            {
                await _cacheManager.AddOrUpdateAsync(id, news, new CacheItemPolicy
                {
                    ExpirationMode = ExpirationMode.Absolute,
                    AbsoluteExpiration = DateTime.Now.AddHours(24),
                });
            }

            return news;
        }
    }
}

*/