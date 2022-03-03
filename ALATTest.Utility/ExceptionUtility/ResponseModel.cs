using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Utility
{
    public class ResponseModel
    {
        public object data { get; set; }
        public string message { get; set; }
        public ErrorCodes code { get; set; }
        public bool success { get; set; }
    }

    public enum ErrorCodes
    {
        Successful = 1,
        Failed,
        ValidDataRequired,
        DataNotFound
    }
}
