using CustomerOnboarder.Core.DTO.Request;
using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerOnboarder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authentication;
        public AuthenticationController(IAuthenticationServices authentication)
        {
            _authentication = authentication;
        }

        /// <summary>
        /// Onboarding a new customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Items in the Response UserResponseDto </returns>
        /// <remarks>
        /// 
        /// sample
        /// POST/api/OnboardCustomer
        /// </remarks> 
        /// <response code ="200">Customer onboarded successfully </response>

        [HttpPost("CreateNewCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> OnboardCustomer(UserRequestDto request)
        {
            var result = await _authentication.OnboardCustomer(request);
            if(result.IsSuccessFul)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
