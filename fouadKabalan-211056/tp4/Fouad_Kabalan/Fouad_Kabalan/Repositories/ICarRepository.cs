using Fouad_Kabalan.Models;
using System.Collections.Generic;

namespace Fouad_Kabalan.Repositories
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
