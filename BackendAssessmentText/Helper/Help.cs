using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessmentText.Helper
{
    public class Help
    {
        public static Response<PaginationModel<IEnumerable<UserResponseDto>>> GetResultResponse()
        {
            return new Response<PaginationModel<IEnumerable<UserResponseDto>>>
            {
                Data = new PaginationModel<IEnumerable<UserResponseDto>>
                {
                    PageItems = new List<UserResponseDto>
                   {
                       new UserResponseDto()
                       {
                            Email = "fat12@gm.com",
                            Id=Guid.NewGuid().ToString(),
                            OTP = "456890",
                            LGA = "Shomolu",
                            State = "Lagos",
                            PhoneNumber ="08141286000"
                       }
                   },
                     CurrentPage = 1,
                     PageSize = 1,
                     PreviousPage = 0,
                     TotalNumberOfPages = 1,
                },
                IsSuccessFul = true,
                Message = "Successful",
                ResponseCode = HttpStatusCode.OK
            };
        }

        public static Response<UserResponseDto> GetResult()
        {
            return new Response<UserResponseDto>
            {
                Data = new UserResponseDto
                {
                    Email = "fat12@gm.com",
                    Id = Guid.NewGuid().ToString(),
                    OTP = "456890",
                    LGA = "Shomolu",
                    State = "Lagos",
                    PhoneNumber = "08141286000"
                },
                IsSuccessFul = true,
                Message = "Successful",
                ResponseCode =HttpStatusCode.OK
            };
        }

        public static Response<ListGetbankDto> GetList()
        {
            return new Response<ListGetbankDto>
            {
                Data = new ListGetbankDto()
                {
                    Result = new List<GetbankDto>
                    {
                        new GetbankDto
                        {
                            BankName ="Wema bank",
                            BankCode = "342682",
                        },
                        new GetbankDto
                        {
                            BankName ="Wema bank",
                            BankCode = "342682",
                        }
                    }
                },
                IsSuccessFul = true,
                Message = "Successful",
                ResponseCode = HttpStatusCode.OK
            };
        }

        
    }
}
