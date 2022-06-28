using AutoMapper;
using CustomerOnboarder.Core.DTO.Request;
using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Services.Interface;
using CustomerOnboarder.Core.Utility;
using CustomerOnboarder.Infrastructure.Model;
using CustomerOnboarder.Infrastructure.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Implementation.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<Response<PaginationModel<IEnumerable<UserResponseDto>>>> GetAllOnboarded(int pageSize, int pageNumber)
        {
            var users = await _repository.GetAllOnBoardedCustomers();
            if (users.Count() >= pageSize)
            {
                var userRes = _mapper.Map<IEnumerable<UserResponseDto>>(users);
                if (users != null)
                {
                    var userResult = PaginationClass.PaginationAsync(userRes, pageSize, pageNumber);
                    return new Response<PaginationModel<IEnumerable<UserResponseDto>>>
                    {
                        Data = userResult,
                        IsSuccessFul = true,
                        ResponseCode = HttpStatusCode.OK,
                        Message = "Successful"
                    };
                }
                return new Response<PaginationModel<IEnumerable<UserResponseDto>>>
                {
                    IsSuccessFul = false,
                    ResponseCode = HttpStatusCode.BadRequest,
                    Message = "Not Successful"
                };
            }
            throw new ArgumentOutOfRangeException("The pagesize is more that the database size");
        }

        
    }
}
