using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Exceptions;
using BusinessBanking.Domain.Response;
using BusinessBanking.Interface.Services.Auth;
using BusinessBanking.Interface.Services.Notifications;
using BusinessBanking.Interface.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BusinessBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IDeviceTokenService _deviceTokenService;

        public AuthController(IAuthService authService, IDeviceTokenService deviceTokenService)
        {
            _authService = authService;
            _deviceTokenService = deviceTokenService;
        }

        [HttpPost("Login")]
        public ActionResult<LoginResponse> Login(LoginDto loginDto)
        {
            var token = _authService.GenerateToken(loginDto.Login, loginDto.Password);

            if (token == null)
            {
                return BadRequest("Invalid credentials");
            }

            var response = new LoginResponse();

            try
            {
                var userID = _authService.FindUserId(loginDto.Login);

                _deviceTokenService.SaveDeviceToken(userID, loginDto.DeviceToken);
            }
            catch
            {
                response.Description = $"User not found for the login: {loginDto.Login}";
            }

            response.Token = token;

            return Ok(response);
        }
    }
}
