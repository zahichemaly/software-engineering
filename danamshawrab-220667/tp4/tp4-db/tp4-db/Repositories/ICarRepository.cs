using tp4_db.Models;

namespace tp4_db.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> Get();
        Car Get(string id);
        Car Create(Car car);
        void Update(string id, Car carIn);
        void Remove(Car carIn);
        void Remove(string id);

    }
}
