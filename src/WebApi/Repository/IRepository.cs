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
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
