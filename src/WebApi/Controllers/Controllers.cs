using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]

/// <summary>
/// ����������. ��������� 2 �����: ������ ������������ �� id � ���������� ������ ������������
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
    }
}