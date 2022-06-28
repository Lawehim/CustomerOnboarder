using CustomerOnboarder.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerOnboarder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userServices;
        public CustomerController(IUserService userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Get all Onboarded Customer
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns>Items in the Response List of UserResponseDto </returns>
        /// <remarks>
        /// 
        /// sample
        /// GET/api/GetAllCustomer
        /// </remarks> 
        /// <response code ="200">Get onboarded customer successfully</response>
        [HttpGet("GetAllOnBoardedCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOnBoardedCustomersAsync(int pageSize, int pageNumber)
        {
            var result = await _userServices.GetAllOnboarded(pageSize, pageNumber);
            return Ok(result);
        }

    }
}
