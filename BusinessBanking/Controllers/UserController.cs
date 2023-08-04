using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userService.GetUsers());
        }

        [Authorize]
        [HttpGet("Test")]
        public object Test()
        {
            return "Success";
        }
    }
}
