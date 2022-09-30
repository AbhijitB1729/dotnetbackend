using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegisterAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegisterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class DetailsController : Controller
    {
        private readonly DetailsAPIDbContext dbContext;
        private readonly IConfiguration _config;
       public DetailsController(DetailsAPIDbContext dbContext,IConfiguration config)
        {
            this.dbContext=dbContext;
            _config= config;
        }   

        [HttpPost]
        [Route("LoginUsers")]

        public async Task<IActionResult> LoginUsers([FromBody] User user)
        {
            var userAvailable =
                await dbContext.Details.Where(x => x.Email == user.Email && x.Password ==  user.Password).FirstOrDefaultAsync();
           if (userAvailable != null)
            {
                var token = GenerateToken(userAvailable.Email);
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Logged in successfully",
                    JwtToken = token
                });

            };
            return Unauthorized("incorrect credentials ");
           
        }
      private string GenerateToken(string email)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,email),
                new Claim("CompanyName","QBurst")
            };
            var token = new JwtSecurityToken(
              issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: credential); 

            
            return tokenhandler.WriteToken(token);
        }
       
            
            
            
            
            [HttpGet]
        public async Task<IActionResult> GetDetails()
        {
            return Ok(await dbContext.Details.ToListAsync(
                ));
            
        }

        [HttpPost]  

        public async Task<IActionResult> AddUser(Detail detail)
        {
            var user = new Detail()
            {
                Email = detail.Email,
                Password = detail.Password,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
            };
            if (!dbContext.Details.Any(u => u.Email == user.Email))
            {
                
               await dbContext.Details.AddAsync(user);
               await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            else
            {
               
                return BadRequest("Entity already exists");
            }
           
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteUser(string email )
        {
            var user = await dbContext.Details.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                dbContext.Details.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();  
        }
    }
}
