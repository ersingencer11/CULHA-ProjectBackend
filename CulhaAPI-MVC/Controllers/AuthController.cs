
using DataLayer.Repository;
using DataLayer.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CulhaAPI_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CulhaDbContext context = new CulhaDbContext();

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto req)
        {

            if (context.Users.Where(user => user.Username == req.username || user.Password == req.password).ToList().Count > 0)
            {
                return BadRequest("Başka bir kullanıcı adı ya da parola seçin");
            }
            else
            {
                User user = new User();
                CreatePasswordHash(req.password, out byte[] passwordHash, out byte[] passwordSalt);
                                
                user.Username = req.username;
                user.Password= req.password;
                user.Role = req.role;
                user.PasswordHash = passwordHash; 
                user.PasswordSalt = passwordSalt; 

                context.Users.Add(user);
                context.SaveChanges();
                return Ok(user);
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserDto req)
        {
            if (context.Users.Where(user=>user.Username==req.username).ToList().Count==0)
            {
                return BadRequest("User not found");
            }
            User user = context.Users.Where(user => user.Username == req.username).SingleOrDefault();
            if (VerifyPasswordHash(req.password, user.PasswordHash,user.PasswordSalt)) ////veritabanında değerin türünü değiştirmek lazım
            {
                string token = CreateToken(user);
                return Ok(token);
            }
            return BadRequest("wrong password");           
        }
        

       private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                //new Claim(ClaimTypes.Role, "admin")
            };  

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds
                );

            var jwt= new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.SequenceEqual(passwordHash))
                {
                    return true;
                }
                return false;
            }
        }




        
    }
}
