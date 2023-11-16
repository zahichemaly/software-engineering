using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp4.Models;

namespace tp4.Repositories
{
    interface ICarRepository
    {
        IEnumerable<Cars> Get();
        Cars Get(string id);
        Cars Create(Cars car);
        void Update(string id, Cars carIn);
        void Remove(Cars carIn);
        void Remove(string id);
    }
}
