namespace WebApi.Repository
{
    /// <summary>
    /// Определяет методы для работы с БД
    /// </summary>
    /// <typeparam name="T">Образ записи</typeparam>
    public interface IRepository<T> where T : UserBase
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(int id);
        public Task<bool> Add(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
