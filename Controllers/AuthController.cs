using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieCollectionAPI.Data;
using MovieCollectionAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;

namespace MovieCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly DataContext dbContext;

        public AuthController(IConfiguration configuration, DataContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = Encoding.UTF8.GetBytes(passwordHash)
            };

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null)
            {
                return BadRequest("User doesn't exist.");
            }

            if (user.PasswordHash == null ||
                !BCrypt.Net.BCrypt.Verify(request.Password, Encoding.UTF8.GetString(user.PasswordHash)))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new() /* List<Claim> */
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
