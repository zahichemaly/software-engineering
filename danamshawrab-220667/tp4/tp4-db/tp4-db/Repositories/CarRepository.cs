using MongoDB.Driver;
using tp4_db.Models;

namespace tp4_db.Repositories
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

        public Car Create(Car car)
        {
            cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn)
        {
            cars.ReplaceOne(car => car.Id == id, carIn);
        }

        public void Remove(Car carIn)
        {
            cars.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            cars.DeleteOne(car => car.Id == id);
        }

    }
}
