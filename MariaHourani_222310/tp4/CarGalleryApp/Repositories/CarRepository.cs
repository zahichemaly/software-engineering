using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CarGalleryApp.Models;


namespace CarGalleryApp.Models.Repositories
{
    public class CarRepository :ICarRepository
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
            cars.InsertOne(car); //Inserting the car into the mongodb collection
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
            throw new NotImplementedException();
        }


       /* public void Update(string id, Car carIn)
        {
            var filter = Builders<Car>.Filter.Eq(c => c.Id, id);

            var update = Builders<Car>.Update
                .Set(c => c.Brand, carIn.Brand)
                .Set(c => c.Model, carIn.Model)
                .Set(c => c.Year, carIn.Year)
                .Set(c => c.Price, carIn.Price)
                .Set(c => c.ImageUrl, carIn.ImageUrl);

            cars.UpdateOne(filter, update);
        }*/
        public void Update(string id, Car carIn)
        {
            cars.ReplaceOne(car => car.Id == id, carIn);
        }
        public void Remove(string id)
        {
            cars.DeleteOne(car => car.Id == id);
        }

    }
}
