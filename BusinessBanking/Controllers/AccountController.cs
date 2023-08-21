using BusinessBanking.Domain.DTO;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Services.CustomerAccounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BusinessBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICustomerAccountService _customerAccountService;
        private readonly ICustomerAccountNameService _customerAccountNameService;

        public AccountController(ICustomerAccountService customerAccountService, ICustomerAccountNameService customerAccountNameService)
        {
            _customerAccountService = customerAccountService;
            _customerAccountNameService = customerAccountNameService;
        }

        [Authorize]
        [HttpGet("GetCustomerAccounts")]
        public async Task<ActionResult<List<CustomerAccount>>> GetCustomerAccounts()
        {
            var identity = User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var isCustomerFound = int.TryParse(claims.Where(p => p.Type == "customerID").FirstOrDefault()?.Value, out int customerId);
                
                if (!isCustomerFound)
                {
                    return NotFound("CustomerNotFound");
                }

                return Ok(await _customerAccountService.GetCustomerAccounts(customerId));
            }

            return NotFound("CustomerNotFound");
        }

        [Authorize]
        [HttpPost("CustomerAccountRename")]
        public async Task<CustomerAccountNameDto> CustomerAccountRename(CustomerAccountNameDto customerAccountNameDto)
        {
            return await _customerAccountNameService.CustomerAccountRename(customerAccountNameDto);
        }
    }
}
