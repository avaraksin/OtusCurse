namespace WebApi.Repository
{
    /// <summary>
    /// Работа с БД
    /// </summary>
    public class RepoEF<T> : IRepository<T> where T : UserBase 
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly AppFactory _appFactory;

        public RepoEF(AppFactory appFactory)
        {
            _appFactory = appFactory;
        }

        /// <summary>
        /// Получить все записи из таблицы.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Get()
        {
            return await _appFactory.Set<T>().ToListAsync();
        }


        /// <summary>
        /// Получить запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> Get(int id)
        {
            return await _appFactory.Set<T>().FirstOrDefaultAsync(x => x.id == id);
        }


        /// <summary>
        /// Добавить новую запись
        /// </summary>
        /// <param name="entity">Образ записи</param>
        /// <returns>
        /// True - в случае успешного добавления записи
        /// False - если запись с таким id уже существует
        /// </returns>
        public async Task<bool> Add(T entity)
        {
            var existEntity = _appFactory.Set<T>().CountAsync(x => x.id == entity.id).Result;
            if (existEntity == 0)
            {
                await _appFactory.Set<T>().AddAsync(entity);
                await _appFactory.SaveChangesAsync();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Обновить запись 
        /// </summary>
        /// <param name="entity">Образ записи</param>
        /// <returns></returns>
        public async Task<bool> Update(T entity)
        {
            var existEntity = _appFactory.Set<T>().FirstOrDefaultAsync(x => x.id == entity.id).Result;
            if(existEntity != null)
            {
                _appFactory.Set<T>().Remove(existEntity);
                _appFactory.Set<T>().Add(entity);
                await _appFactory.SaveChangesAsync();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Удалить запись по id
        /// </summary>
        /// <param name="id">id для удаления</param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            var existEntity = _appFactory.Set<T>().FirstOrDefaultAsync(x => x.id == id).Result;
            if (existEntity != null)
            {
                _appFactory.Set<T>().Remove(existEntity);
                await _appFactory.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
