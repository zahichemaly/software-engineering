using eShop.Core.Entities;
using eShop.Core.Interfaces;
using MongoDB.Driver;
using MongoDbGenericRepository;

namespace eShop.Infrastructure.Data
{
    public class MongoDbRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDbRepository(IMongoDbContext mongoDbContext)
        {
            _collection = mongoDbContext.GetCollection<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _collection.FindAsync(_ => true);
            var result = await data.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var data = await _collection.FindAsync(x => x.Id == id);
            var result = await data.FirstOrDefaultAsync();
            return result;
        }

        public async Task<long> GetCountAsync()
        {
            return await _collection.CountDocumentsAsync(_ => true);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            var options = new FindOneAndReplaceOptions<T, T>()
            {
                ReturnDocument = ReturnDocument.After
            };
            var result = await _collection.FindOneAndReplaceAsync(filter, entity, options);
            return result;
        }
    }
}
