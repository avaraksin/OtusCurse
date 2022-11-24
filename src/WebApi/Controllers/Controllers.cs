using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]

/// <summary>
/// Контроллер. Реализует 2 ручки: Запрос пользователя по id и добавление нового пользователя
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
    }
}