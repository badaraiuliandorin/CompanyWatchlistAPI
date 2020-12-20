using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWatchlistAPI.Controllers
{
    [Route("api/watchlist/[action]")]
    [Route("api/watchlist/[action]/id")]
    [Route("api/watchlist/[action]/userId")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IWatchlistRepository _watchlistRepository;
        private readonly IUserRepository _userRepository;

        public WatchlistController(IWatchlistRepository watchlistRepository, IUserRepository userRepository)
        {
            _watchlistRepository = watchlistRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var user = _userRepository.GetOne(x => x.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }

            var items = _watchlistRepository.Get(x => x.UserId == user.Id);

            return Ok(items);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _watchlistRepository.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var item = _watchlistRepository.GetOne(x => x.Id == id);

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add(Watchlist watchlist)
        {
            if (watchlist == null)
                return BadRequest();

            var result = _watchlistRepository.Insert(watchlist);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _watchlistRepository.Delete(id);

            return Ok();
        }
    }
}
