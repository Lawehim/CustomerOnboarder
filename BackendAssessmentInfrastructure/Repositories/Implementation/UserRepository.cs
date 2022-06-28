using CustomerOnboarder.Infrastructure.Context;
using CustomerOnboarder.Infrastructure.Model;
using CustomerOnboarder.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Infrastructure.Repositories.Implementation
{
    public class UserRepository: IUserRepository
    {
        private readonly BackendContext _dbContext;
        private readonly DbSet<Customer> _customers;
        public UserRepository(BackendContext dbContext)
        {
            _dbContext = dbContext;
            _customers = _dbContext.Customers;
        }

        public async Task<bool> OnboardCustomer(Customer customer)
        {
            await _customers.AddAsync(customer);
            return await Save();
        }
        public async Task<Customer> CheckUser(string email)
        {
            return await _customers.FirstOrDefaultAsync(x=>x.Email==email);
        }

        public async Task<IEnumerable<Customer>> GetAllOnBoardedCustomers()
        {
           return await _dbContext.Customers.ToListAsync();
        }

        private async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
