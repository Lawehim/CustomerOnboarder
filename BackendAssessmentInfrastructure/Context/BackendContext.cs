using CustomerOnboarder.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Infrastructure.Context
{
    public class BackendContext : DbContext
    {
        public BackendContext(DbContextOptions<BackendContext> options):base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
