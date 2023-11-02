using MongoDB.Driver;
using WebApplication1.Models;
using WebApplication1.CarRepository;
using WebApplication1.Models;

namespace WebApplication1.CarRepository
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
            var filter = Builders<Car>.Filter.Eq(c => c.Id, carIn.Id);
            cars.DeleteOne(filter);
        }

        public void Remove(string id)
        {
            var filter = Builders<Car>.Filter.Eq(c => c.Id, id);
            cars.DeleteOne(filter);
        }

        public void Update(string id, Car carIn)
        {
            var filter = Builders<Car>.Filter.Eq(c => c.Id, id);
            var replacement = carIn;
            var options = new UpdateOptions
            {
                IsUpsert = false
            };



            cars.ReplaceOne(filter, replacement, options);
        }
    }
}