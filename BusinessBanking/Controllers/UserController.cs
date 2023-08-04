using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace BusinessBanking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}
