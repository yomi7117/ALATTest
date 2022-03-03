using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Domain.Models
{
    public class Customer: BaseEntity
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsCompleted { get; set; }
        public State State { get; set; }
        public LGA LGA { get; set; }
    }
}
