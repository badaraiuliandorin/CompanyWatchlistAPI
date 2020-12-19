using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWatchlistAPI.Controllers
{
    [Route("api/user/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _userRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var item = _userRepository.GetOne(x => x.Id == id);

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            if (user == null)
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
