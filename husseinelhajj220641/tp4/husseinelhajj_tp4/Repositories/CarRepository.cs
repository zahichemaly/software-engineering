using husseinelhajj_tp4.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;

namespace husseinelhajj_tp4.Repositories
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

        public Car Create(Car car)
        {
            cars.InsertOne(car);
            return car;
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
            var filter = Builders<Car>.Filter.Eq("Id", id); // Create a filter to match the car with the given id
            cars.ReplaceOne(filter, carIn); // Replace the matched car with the updated car
        }
    }
}
