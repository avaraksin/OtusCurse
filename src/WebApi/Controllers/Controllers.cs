using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class Controllers : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRepository<User> _repo;

        public Controllers(IRepository<User> repo)
        {
            _repo = repo;
        }

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

        [HttpPost("")]   
        public Task<long> CreateCustomerAsync([FromBody] User customer)
        {
            throw new NotImplementedException();
        }
    }
}