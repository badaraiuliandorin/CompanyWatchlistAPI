using CompanyWatchlistAPI.Models;
using CompanyWatchlistAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CompanyWatchlistAPI.Controllers
{
    [Route("api/user/[action]")]
    [Route("api/user/[action]/id")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
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

            var result = _userRepository.Insert(user);

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(Login login)
        {
            IActionResult response = Unauthorized();

            var result = _userRepository.Login(login);

            if (result != null)
            {
                var token = CreateToken(result);
                response = Ok(new { token });
            }

            return response;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               _configuration["Jwt:Issuer"],
               _configuration["Jwt:Issuer"],
               claims,
              expires: DateTime.Now.AddMinutes(180),  //60 min expiry and a client monitor token quality and should request new token with this one expiries
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            var adminRoleId = _roleRepository.Get(x => x.Name == "Admin").FirstOrDefault().Id;
            var user = _userRepository.GetOne(x => x.Id == id);
            if (user.RoleId == adminRoleId)
                return BadRequest();

            _userRepository.Delete(id);

            return Ok();
        }
    }
}
