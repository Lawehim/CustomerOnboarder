using CustomerOnboarder.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Infrastructure.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<bool> OnboardCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllOnBoardedCustomers();
        Task<Customer> CheckUser(string email);
    }
}
