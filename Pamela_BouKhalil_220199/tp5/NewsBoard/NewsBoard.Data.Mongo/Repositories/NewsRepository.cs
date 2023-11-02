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
    public class NewsRepository:INewsRepository
    {
        private readonly IMongoCollection<News> _collection;
        public NewsRepository(MongoClient client)
        {
            IMongoDatabase database = client.GetDatabase("NewsBoard");
            _collection = database.GetCollection<News>(nameof(News));
        }

        public async Task<IEnumerable<News>> Get()
        {
            var news = await _collection.Find(_ => true).ToListAsync();
            return news;
        }

        public async Task<News> Get(string id)
        {
            var news = await _collection.Find(n => n.Id == id).FirstOrDefaultAsync();
            return news;
        }

        public async Task Add(News news)
        {
            await _collection.InsertOneAsync(news);
        }

        public async Task Update(News news)
        {
            var filter = Builders<News>.Filter.Eq(n => n.Id, news.Id);
            await _collection.ReplaceOneAsync(filter, news);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<News>.Filter.Eq(n => n.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public IEnumerable<News> GetAllNews()
        {
            return _collection.Find(_ => true).ToList(); // Example implementation, adjust as needed.
        }
    }

}

