using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Services.Interface
{
    public interface IUserService
    {
        Task<Response<PaginationModel<IEnumerable<UserResponseDto>>>> GetAllOnboarded(int pageSize, int pageNumber);
    }
}
