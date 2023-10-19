using MongoDB.Bson;
using MongoDB.Driver;
using TP4.Models;

namespace TP4.Repositories
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
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }



        public void Update(string id, Car carIn)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                throw new ArgumentException("Invalid ObjectId format for 'id'.");
            }

            
            var filter = Builders<Car>.Filter.Eq("_id", objectId);

           
            var update = Builders<Car>.Update
                .Set("Brand", carIn.Brand) 
                .Set("Model", carIn.Model)  
                .Set("Year", carIn.Year)
                .Set("Price", carIn.Price)
                .Set("Photo",carIn.ImageUrl);

            
            var result = cars.ReplaceOne(filter, carIn);

            if (result.IsAcknowledged && result.ModifiedCount == 1)
            {
                // Document updated successfully
            }
            else
            {
                // Handle the case where the document was not updated
                throw new InvalidOperationException("Update operation did not succeed.");
            }
        }
    }
}
