using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DatingApp.API.Models;
using DatingApp.API.Dtos;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        public AuthController(IAuthRepository repo)
        {
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task <IActionResult> Register (UserForRegisterDTO userForRegisterDto)
        {
            // validate request HERE
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if(await repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };
            var createdUser = await repo.Register(userToCreate,userForRegisterDto.Username);
            
            return StatusCode(201);
        }

    }
}