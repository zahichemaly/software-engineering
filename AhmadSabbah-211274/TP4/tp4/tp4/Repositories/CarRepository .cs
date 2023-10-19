using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp4.Models;

namespace tp4.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCollection<Cars> cars;
        public CarRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("CarGalleryDb"));
            IMongoDatabase database = client.GetDatabase("CarGalleryDb");
            cars = (IMongoCollection<Cars>)database.GetCollection<Cars>("Cars");
        }
        public IEnumerable<Cars> Get()
        {
            return cars.Find(car => true).ToList();
        }
        public Cars Get(string id)
        {
            return cars.Find(car => car.Id == id).FirstOrDefault();
        }
        public Cars Create(Cars car)
        {
            cars.InsertOne(car );
            return car;
        }
        public void Update(string id, Cars carIn)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Id, id);
            var replacement = carIn;
            var options = new UpdateOptions
            {
                IsUpsert = false
            };



            cars.ReplaceOne(filter, replacement, options);
        }





        public void Remove(Cars carIn)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Id, carIn.Id);
            cars.DeleteOne(filter);

        }

        public void Remove(string id)
        {
            var filter = Builders<Cars>.Filter.Eq(c => c.Id, id);
            cars.DeleteOne(filter);
        }

       

        
    }
}
