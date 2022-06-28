using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Utility
{
    public class OtpGenerator
    {
        public static string GenerateOTP()
        {
            Random rand = new();
            return Convert.ToString((double)rand.Next(100000, 999999));
        }
    }
}
