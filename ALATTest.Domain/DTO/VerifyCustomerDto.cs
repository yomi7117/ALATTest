using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Domain.DTO
{
    public class VerifyCustomerDto
    {
        public long CustomerId { get; set; }
        public string OTP { get; set; }
    }
}
