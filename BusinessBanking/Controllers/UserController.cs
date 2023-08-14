using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                //var customerId = claims.Where(p => p.Type == "customerID").FirstOrDefault()?.Value;
                if (int.TryParse(claims.Where(p => p.Type == "customerID").FirstOrDefault()?.Value, out int customerId))
                {
                    return new
                    {
                        data = customerId
                    };
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
