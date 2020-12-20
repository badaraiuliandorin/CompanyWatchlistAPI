using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
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
        public IActionResult GetAll()
        {
            var items = _roleRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var item = _roleRepository.GetOne(x => x.Id == id);

            return Ok(item);
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var user = _userRepository.GetOne(x => x.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }

            var item = _roleRepository.GetOne(x => x.Id == user.RoleId);

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (role == null)
                return BadRequest();

            _roleRepository.Insert(role);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roleRepository.Delete(id);

            return Ok();
        }
    }
}
