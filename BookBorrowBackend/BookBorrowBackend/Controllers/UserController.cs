using Buisness_Layer.IService;
using Buisness_Layer.Models;
using DataAccessLayer.Db;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookBorrowBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserService userService;

        public UserController( IUserService userService)
        {
         
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
           
            var verify = await userService.VerifyAsync(user);
            if (verify == null)
            {
                return NotFound("Login fails");
            }
            else
            {

                return Ok(new
                {
                    Message = "Login Success!!",
                    Token = verify.Token
                });
            }

        }
        [HttpGet("getUserById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
  
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("getAvailableToken/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetAvailableToken([FromRoute] int userId)
        {
            if (userId == 0)
            {
                return BadRequest();
            }
      
            var user = await userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.TokenAvailable);
        }

    }
}
