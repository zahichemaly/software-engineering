using tp4gl.Models;

namespace tp4gl.Repositories
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
