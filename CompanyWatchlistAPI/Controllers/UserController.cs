using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompanyWatchlistAPI.Controllers
{
    [Route("api/user/[action]")]
    [Route("api/user/[action]/id")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult GetAll()
        {
            var items = _userRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetOne(int id)
        {
            var item = _userRepository.GetOne(x => x.Id == id);

            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Add(User user)
        {
            var adminRoleId = _roleRepository.Get(x => x.Name == "Admin").FirstOrDefault().Id;
            if (user == null || user.RoleId == adminRoleId)
                return BadRequest();

            _userRepository.Insert(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);

            return Ok();
        }
    }
}
