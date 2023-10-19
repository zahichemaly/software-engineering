using CarGalleryApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarGalleryApp.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCollection<Car> cars;

       
        public IEnumerable<Car> Get()
        {
            return cars.Find(car => true).ToList();
        }
        public Car Get(string id)
        {
            return cars.Find(car => car.Id == id).FirstOrDefault();
        }

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
            var filter = Builders<Car>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Car>.Update
                .Set("Brand", carIn.Brand)
        .Set("Model", carIn.Model)
        .Set("Year", carIn.Year)
        .Set("Price", carIn.Price)
        .Set("ImageUrl", carIn.ImageUrl);

            var result = cars.UpdateOne(filter, update);

        }

    }
}
