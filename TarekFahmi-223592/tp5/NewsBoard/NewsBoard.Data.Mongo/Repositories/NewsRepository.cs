using MongoDB.Driver;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBoard.Data.Mongo.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly IMongoCollection<News> _collection;
        public NewsRepository(MongoClient client)
        {
            IMongoDatabase database = client.GetDatabase("NewsBoard");
            _collection = database.GetCollection<News>(nameof(News));
        }
        public async Task<IEnumerable<News>> Get()
        {
            return await _collection.Find(_ => true).SortByDescending(n => n.CreatedDate).ToListAsync();
        }

        public async Task<News> Get(string id)
        {
            var filter = Builders<News>.Filter.Eq(n => n.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Add(News news)
        {
            news.Id = Guid.NewGuid().ToString();
            news.CreatedDate = DateTime.UtcNow;
            news.Views = 0;
            news.Rating = 0;
            await _collection.InsertOneAsync(news);
        }

        public async Task Update(News news)
        {
            var filter = Builders<News>.Filter.Eq(n => n.Id, news.Id);
            var update = Builders<News>.Update
                .Set(n => n.Headline, news.Headline)
                .Set(n => n.Article, news.Article)
                .Set(n => n.ModifiedDate, DateTime.UtcNow)
                .Inc(n => n.Rating, news.Rating);
            await _collection.UpdateOneAsync(filter, update);
        }
        public async Task Delete(string id)
        {
            var filter = Builders<News>.Filter.Eq(n => n.Id, id);
            await  _collection.DeleteOneAsync(filter);
        }

    }
}
