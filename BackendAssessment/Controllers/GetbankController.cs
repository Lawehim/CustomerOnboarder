using CustomerOnboarder.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerOnboarder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetbankController : ControllerBase
    {
        private readonly IGetBankServices _getBankServices;
        public GetbankController(IGetBankServices getBankServices)
        {
            _getBankServices = getBankServices;
        }

        /// <summary>
        /// Get all BankName and BankCode
        /// </summary>
        /// <returns>Items in the Response List of Getbanks </returns>
        /// <remarks>
        /// 
        /// sample
        /// GET/api/GetBank
        /// </remarks> 
        /// <response code ="200">Get bank successfully</response>
        [HttpGet("Getbanks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBanks()
        {
            var result = await _getBankServices.GetbankRequest();
            if (result.IsSuccessFul)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
