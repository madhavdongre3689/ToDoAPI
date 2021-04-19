using ToDoListAPI.Entities;
using ToDoListAPI.Identity;
using ToDoListAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListAPI.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {

        private ToDoContext _todoContext;
        private IPasswordHasher<User> _passwordHasher;

        private IJwtProvider _jwtProvider;
        public AccountController(ToDoContext todoContext, IPasswordHasher<User> passwordHasher, IJwtProvider jwtProvider)
        {
            _todoContext = todoContext;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userDto)
        {
            //var user = _meetupContext.Users.Include(a => a.RoleId).FirstOrDefault(user => user.Email == userDto.UserName);
            var user = _todoContext.Users.FirstOrDefault(u => u.Email == userDto.UserName);
            if (user == null)
            {
                return BadRequest("Invalid UserName or Password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return BadRequest("Invalid UserName or Password");
            }
            var token = _jwtProvider.GenerateJwtToken(user);
            return Ok(token);

        }

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDto usertodo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                User newuser = new User
                {
                    Email = usertodo.Email,
                    FirstName=usertodo.FirstName,
                    LastName =usertodo.LastName
                };
                var _passwordHash = _passwordHasher.HashPassword(newuser, usertodo.Password);
                newuser.PasswordHash = _passwordHash;
                _todoContext.Users.Add(newuser);
                _todoContext.SaveChanges();
                return Ok();
            }
        }
    }
}
