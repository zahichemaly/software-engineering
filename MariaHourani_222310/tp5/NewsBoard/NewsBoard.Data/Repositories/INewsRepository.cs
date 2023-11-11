public interface INewsRepository
{
    Task<IEnumerable<News>> Get();
    Task<News> Get(string id);
    Task Add(News news);
    Task Update(News news);
    Task Delete(string id);
}