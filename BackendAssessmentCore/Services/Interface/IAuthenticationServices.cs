using CustomerOnboarder.Core.DTO.Request;
using CustomerOnboarder.Core.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Services.Interface
{
    public interface IAuthenticationServices
    {
        Task<Response<UserResponseDto>> OnboardCustomer(UserRequestDto userRequest);
    }
}
