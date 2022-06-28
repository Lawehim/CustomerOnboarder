using AutoMapper;
using CustomerOnboarder.Core.DTO.Request;
using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Services.Interface;
using CustomerOnboarder.Core.Utility;
using CustomerOnboarder.Infrastructure.Model;
using CustomerOnboarder.Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Services.Implementation
{
    public class AuthenticationServices:IAuthenticationServices
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly IConfirmStateLGA _confirmStateLGA;
        public AuthenticationServices(IMapper mapper, IUserRepository repository, IConfirmStateLGA confirmStateLGA)
        {
            _mapper = mapper;
            _repository = repository;
            _confirmStateLGA = confirmStateLGA;
        }


        public async Task<Response<UserResponseDto>> OnboardCustomer(UserRequestDto userRequest)
        {
            var exist = await _repository.CheckUser(userRequest.Email);

            if (exist != null)
            {
                return new Response<UserResponseDto>
                {
                    Message = "User already exist with this email",
                    IsSuccessFul = false,
                    ResponseCode = HttpStatusCode.Conflict
                };
            }
            var check = await _confirmStateLGA.Confirmation(userRequest.State, userRequest.LGA);
            if (check)
            {
                var user = _mapper.Map<Customer>(userRequest);
                user.Id = Guid.NewGuid().ToString();
                user.OTP = OtpGenerator.GenerateOTP();
                var result = await _repository.OnboardCustomer(user);
                if (result)
                {
                    var userResponse = _mapper.Map<UserResponseDto>(user);
                    return new Response<UserResponseDto>
                    {
                        Data = userResponse,
                        Message = "Successful",
                        IsSuccessFul = true,
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<UserResponseDto>
                {
                    Message = "Not Successful",
                    IsSuccessFul = false,
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            return new Response<UserResponseDto>
            {
                Message = "Customer State and LGA not valid",
                IsSuccessFul = false,
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

    }
}
