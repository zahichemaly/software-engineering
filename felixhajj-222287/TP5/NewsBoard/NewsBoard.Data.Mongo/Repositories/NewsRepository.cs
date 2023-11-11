﻿using MongoDB.Driver;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

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

        public async Task Add(News news)

        {

            await _collection.InsertOneAsync(news);

        }

        public async Task Delete(string id)

        {

            var filter = Builders<News>.Filter.Eq("_id", id);

            await _collection.DeleteOneAsync(filter);

        }

        public async Task<IEnumerable<News>> Get()

        {

            var filter = Builders<News>.Filter.Empty;

            var news = await _collection.Find(filter).ToListAsync();

            return news;

        }

        public async Task<News> Get(string id)

        {

            var filter = Builders<News>.Filter.Eq("_id", id);

            var news = await _collection.Find(filter).FirstOrDefaultAsync();

            return news;

        }

        public async Task Update(News news)

        {

            var filter = Builders<News>.Filter.Eq("_id", news.Id);

            await _collection.ReplaceOneAsync(filter, news);

        }

    }

}
