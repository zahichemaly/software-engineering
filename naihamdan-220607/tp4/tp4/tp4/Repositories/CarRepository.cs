using System;
using MongoDB.Driver;
using tp4.Models;

namespace tp4.Repositories
{
	public class CarRepository : ICarRepository
	{
        private readonly IMongoCollection<Car> cars;
        public CarRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("CarGalleryDb"));
            IMongoDatabase database = client.GetDatabase("CarGalleryDb");
            cars = database.GetCollection<Car>("Cars");
        }

        public IEnumerable<Car> Get()
        {
            return cars.Find(car => true).ToList();
        }
        public Car Get(string id)
        {
            return cars.Find(car => car.Id == id).FirstOrDefault();
        }

        public void Remove(Car carIn)
        {
            var filter = Builders<Car>.Filter.Eq(car => car.Id, carIn.Id);
            cars.DeleteOne(filter);
        }

        public void Remove(string id)
        {
            var filter = Builders<Car>.Filter.Eq(car => car.Id, id);
            cars.DeleteOne(filter);
        }

        public void Update(string id, Car carIn)
        {
            var filter = Builders<Car>.Filter.Eq(car => car.Id, id);

            cars.ReplaceOne(filter, carIn);
        }

        Car ICarRepository.Create(Car car)
        {
            cars.InsertOne(car);
            return car;
        }
    }
}

