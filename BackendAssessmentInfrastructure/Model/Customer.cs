using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Infrastructure.Model
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
        [Required]
        public string OTP { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string LGA { get; set; }
    }
}
