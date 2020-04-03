using DatingApp.API.Dtos;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository repo;
        private readonly IConfiguration config;


        public UsersController(IDatingRepository repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.config = configuration;
        }

        [HttpGet]
        public async Task <IActionResult> GetUsers()
        {
            var users = await repo.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUser (int id)
        {
            var user = await repo.GetUser(id);
            return Ok(user);
        }

    }
}
