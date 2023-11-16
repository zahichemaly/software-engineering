using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Repo
{
    public class CarRepository: ICarRepository
    {
        
        
            private readonly IMongoCollection<Car> _cars;
            public CarRepository(IConfiguration config)
            {
                MongoClient client = new MongoClient(config.GetConnectionString("CarGalleryDb"));
                IMongoDatabase database = client.GetDatabase("CarGalleryDb");
                _cars = database.GetCollection<Car>("Cars");
            }


            public IEnumerable<Car> Get()
            {
                return _cars.Find(car => true).ToList();
            }

            public Car Get(string id)
            {
                return _cars.Find<Car>(car => car.Id == id).FirstOrDefault();
            }

            public Car Create(Car car)
            {
            
                _cars.InsertOne(car); 
                return car; 
            
            }
        public void Update(string id, Car carIn)
        {
            var filter = Builders<Car>.Filter.Eq("_id", ObjectId.Parse(id)); 
            var options = new ReplaceOptions { IsUpsert = false }; 

            _cars.ReplaceOne(filter, carIn, options);
        }

        public void Remove(Car carIn)
        {
            _cars.DeleteOne(car => car.Id == carIn.Id);
        }

        public void Remove(string id)
        {
            _cars.DeleteOne(car => car.Id == id);
        }



    }
}
