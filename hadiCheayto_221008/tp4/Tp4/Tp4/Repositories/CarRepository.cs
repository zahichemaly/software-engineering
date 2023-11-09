using MongoDB.Driver;
using Tp4.Models;

namespace Tp4.Repositories
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
            cars.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            cars.DeleteOne(car => car.Id == id);
        }

        public void Update(string id, Car carIn)
        {
            var filter = Builders<Car>.Filter.Eq(car => car.Id, id);

            var update = Builders<Car>.Update
                .Set(car => car.Brand, carIn.Brand)
                .Set(car => car.Price, carIn.Price)
                .Set(car => car.Model, carIn.Model)
                .Set(car => car.ImageUrl, carIn.ImageUrl)
                .Set(car => car.Year, carIn.Year);

            cars.UpdateOne(filter, update);
        }
    }
}
