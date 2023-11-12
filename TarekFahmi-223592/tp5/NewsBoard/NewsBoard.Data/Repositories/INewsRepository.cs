using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsBoard.Data.Entities;
namespace NewsBoard.Data.Repositories
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> Get();
        Task<News> Get(string id);
        Task Add(News news);
        Task Update(News news);
        Task Delete(string id);
    }

}
