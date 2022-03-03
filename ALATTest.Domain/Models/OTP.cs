using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Domain.Models
{
    public class OTP
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public Customer Customer { get; set; }
        public bool IsUsed { get; set; }
    }
}
