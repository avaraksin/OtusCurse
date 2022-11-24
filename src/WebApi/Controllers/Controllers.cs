using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]

/// <summary>
/// Контроллер. Реализует 2 ручки из ДЗ: Запрос пользователя по id и добавление нового пользователя
/// + 3 ручки для проверки методов RepoEF (GetAll, Update & Delete)
/// </summary>
    public class Controllers : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRepository<User> _repo;

        public Controllers(IRepository<User> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns>
        /// Возвращает код 200 и класс User в случае успеха
        /// Код 404 - если пользователя с таким id несуществует
        /// </returns>
        [HttpGet("{id:long}")]   
        public async Task<IActionResult> GetUserAsync([FromRoute] int id)
        {
            var result = await _repo.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Добавить в БД нового пользователя
        /// </summary>
        /// <param name="user">User для добавления в БД</param>
        /// <returns>
        /// Возвращает код 200 и User в случае успеха
        /// 409 - если пользователь с таким id уже существует в Базе
        /// </returns>
        [HttpPost("")]   
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            var result = await _repo.Add(user);
            if (result == false)
            {
                return Conflict();
            }
            return Ok(user);
        }



        /// <summary>
        /// Получить список всех клиентов
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns></returns>
        [HttpGet]   
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.Get();
        }

        /// <summary>
        /// Обновить клиента в  БД
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// true - если такая запись существует. 
        /// false - если нет.
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody]  User user)
        {
            var result = await _repo.Update(user);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(user);
        }



        /// <summary>
        /// Удалить запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// true - если такая запись существует. 
        /// false - если нет.
        /// </returns>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute]  int id)
        {
            var result = await _repo.Delete(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(id);
        }
    }
}