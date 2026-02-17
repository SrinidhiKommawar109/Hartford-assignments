using BasicAuthentication.Data;
using BasicAuthentication.DTOs;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BasicAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor Injection
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            //Model state validation 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //checking email existing or not
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == userDto.Email);

            if (existingUser != null)
                return BadRequest("User already exists");


            var user = new UserLogin
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User registered successfully");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto dto)
        {
            var validUser = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);

            if (validUser == null)
                return Unauthorized("Invalid email or password");
            return Ok("Login successful");
        }
        [HttpGet]
        [Route("GetUserProfile")]
        public IActionResult GetUserProfile(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            // If no users found
            if (users == null || users.Count == 0)
            {
                return NotFound("No users found");
            }
            return Ok(users);
        }

    }
}