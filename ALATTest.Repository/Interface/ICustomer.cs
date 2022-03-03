using ALATTest.Domain.DTO;
using ALATTest.Domain.ViewModel;
using ALATTest.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Repository.Interface
{
    public interface ICustomer
    {
        Task<ResponseModel> AddCustomer(CustomerDto model);
        Task<ResponseModel> GetAllCustomer();
        Task<ResponseModel> VerifyCustomer(VerifyCustomerDto model);
    }
}
