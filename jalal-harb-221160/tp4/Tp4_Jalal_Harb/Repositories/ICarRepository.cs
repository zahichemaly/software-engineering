using Tp4_Jalal_Harb.Models;

namespace Tp4_Jalal_Harb.Repositories
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
