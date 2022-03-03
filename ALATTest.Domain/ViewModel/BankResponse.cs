using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Domain.ViewModel
{
  
        public class bank
        {
            public string bankName { get; set; }
            public string bankCode { get; set; }
        }

        public class BankResponse
        {
            public List<bank> result { get; set; }
            public object errorMessage { get; set; }
            public object errorMessages { get; set; }
            public bool hasError { get; set; }
            public DateTime timeGenerated { get; set; }
        }


    
}
