namespace WebApi.Repository
{
    public class RepoEF<T> : IRepository<T> where T : UserBase 
    {
        private readonly AppFactory _appFactory;

        public RepoEF(AppFactory appFactory)
        {
            _appFactory = appFactory;
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _appFactory.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _appFactory.Set<T>().FirstOrDefaultAsync(x => x.id == id);
        }

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

        public async Task Update(T entity)
        {
            var existEntity = _appFactory.Set<T>().FirstOrDefaultAsync(x => x.id == entity.id).Result;
            if(existEntity != null)
            {
                _appFactory.Set<T>().Remove(existEntity);
                _appFactory.Set<T>().Add(entity);
                await _appFactory.SaveChangesAsync();
            }

        }

        public async Task Delete(int id)
        {
            var existEntity = _appFactory.Set<T>().FirstOrDefaultAsync(x => x.id == id).Result;
            if (existEntity != null)
            {
                _appFactory.Set<T>().Remove(existEntity);
                await _appFactory.SaveChangesAsync();
            }
        }
    }
}
