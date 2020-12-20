using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWatchlistAPI.Controllers
{
    [Route("api/role/[action]")]
    [Route("api/role/[action]/id")]
    [Route("api/role/[action]/userId")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public RoleController(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult GetAll()
        {
            var items = _roleRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetOne(int id)
        {
            var item = _roleRepository.GetOne(x => x.Id == id);

            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Add(Role role)
        {
            if (role == null)
                return BadRequest();

            var result = _roleRepository.Insert(role);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            _roleRepository.Delete(id);

            return Ok();
        }
    }
}
