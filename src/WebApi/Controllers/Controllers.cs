using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]

/// <summary>
/// ����������. ��������� 2 ����� �� ��: ������ ������������ �� id � ���������� ������ ������������
/// + 3 ����� ��� �������� ������� RepoEF (GetAll, Update & Delete)
/// </summary>
    public class Controllers : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRepository<User> _repo;

        public Controllers(IRepository<User> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// �������� ������������ �� id
        /// </summary>
        /// <param name="id">id ������������</param>
        /// <returns>
        /// ���������� ��� 200 � ����� User � ������ ������
        /// ��� 404 - ���� ������������ � ����� id ������������
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
        /// �������� � �� ������ ������������
        /// </summary>
        /// <param name="user">User ��� ���������� � ��</param>
        /// <returns>
        /// ���������� ��� 200 � User � ������ ������
        /// 409 - ���� ������������ � ����� id ��� ���������� � ����
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
        /// �������� ������ ���� ��������
        /// </summary>
        /// <param name="id">id ������������</param>
        /// <returns></returns>
        [HttpGet]   
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repo.Get();
        }

        /// <summary>
        /// �������� ������� �  ��
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// true - ���� ����� ������ ����������. 
        /// false - ���� ���.
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
        /// ������� ������ �� id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// true - ���� ����� ������ ����������. 
        /// false - ���� ���.
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