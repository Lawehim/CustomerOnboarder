using AutoMapper;
using CustomerOnboarder.Core.DTO.Request;
using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.DTO.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<UserResponseDto,Customer>().ReverseMap();
            CreateMap<UserRequestDto, Customer>().ReverseMap();
        }
    }
}
