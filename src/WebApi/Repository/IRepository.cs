namespace WebApi.Repository
{
    public interface IRepository<T> where T : UserBase
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(int id);
        public Task<bool> Add(T entity);
        public Task Update(T entity);
        public Task Delete (int id);
    }
}
