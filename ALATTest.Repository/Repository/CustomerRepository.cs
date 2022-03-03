using ALATTest.Domain.DBContext;
using ALATTest.Domain.DTO;
using ALATTest.Domain.Models;
using ALATTest.Domain.ViewModel;
using ALATTest.Repository.Interface;
using ALATTest.Utility;
using ALATTest.Utility.ExceptionUtility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Repository.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ALATDBContext _context;
        private readonly ILogger<CustomerRepository> _logger;
        private PasswordHasherCustom passwordHasher = new PasswordHasherCustom();

        public CustomerRepository(ALATDBContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
           
        }

        
        public async Task<ResponseModel> AddCustomer(CustomerDto payload)
        {
            var statedata = await _context.States.Where(a => a.Id == payload.StateId).FirstOrDefaultAsync();
            var lagdata =  await _context.LGA.Where(a => a.ID == payload.LGAId && a.State.Id == payload.StateId).FirstOrDefaultAsync();
            var customerExist = await _context.Customers.AnyAsync(a => a.Email == payload.Email);

            if (customerExist)
            {
                return new ResponseModel
                {
                    code = ErrorCodes.Failed,
                    message = string.Format(ResponseErrorMessageUtility.RecordExistBefore, payload.Email),
                    success = false
                };
            }
            try
            {
                Customer customer = new ()
                {
                    PhoneNumber = payload.PhoneNumber,
                    Email = payload.Email,
                    Password = passwordHasher.HashPassword(payload.PhoneNumber),
                    State = statedata,
                    LGA = lagdata,
                    CreatedBy = "System",
                    

                };
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                Random random = new();
                VerifyCustomerDto verifyCustomer = new();
                {
                    verifyCustomer.CustomerId = customer.Id;
                    verifyCustomer.OTP = random.Next(0, 9999).ToString("D4");

                }
                var setotp = SendOTP(verifyCustomer);

                return new ResponseModel
                {
                    code = ErrorCodes.Successful,
                    data = customer,
                    message = "Successsful",
                    success = true,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ResponseModel
                {
                    code = ErrorCodes.Failed,
                    message = string.Format("{0} -ErrorMessage: {1}", ResponseErrorMessageUtility.RecordNotSaved, ex.Message),
                    success = false
                };
            }
        }

        public async Task<ResponseModel> GetAllCustomer()
        {
            try
            {
                var customerdata = await _context.Customers.Where(a => a.IsActive == true && a.IsCompleted == true).Select(a=> new CustomerViewModel
                {
                    email = a.Email,
                    phonenumber = a.PhoneNumber,
                    stateid = a.State.Id,
                    statename = a.State.Name,
                    lgaid = a.LGA.ID,
                    lganame = a.LGA.Name,

                    
                } ).ToListAsync();
                if (customerdata.Count > 0)
                {
                    return new ResponseModel
                    {
                        code = ErrorCodes.Successful,
                        data = customerdata,
                        message = string.Empty,
                        success = true,
                    };
                }
                return new ResponseModel
                {
                    code = ErrorCodes.Successful,
                    data = null,
                    message = "No Data to Fetch",
                    success = true,
                };
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
              return new ResponseModel
                {
                    code = ErrorCodes.Failed,
                    data = null,
                    message = string.Format("{0} -ErrorMessage: {1}", ResponseErrorMessageUtility.RecordNotFetched, ex.Message),
                    success = false,
                };
            }
        }

        public async Task<ResponseModel> VerifyCustomer(VerifyCustomerDto model)
        {
            try
            {

                var otpdata = await _context.OTP.Where(a => a.Token == model.OTP && a.Customer.Id == model.CustomerId).FirstOrDefaultAsync();

                if (otpdata != null)
                {
                    var customerdata = await _context.Customers.FirstOrDefaultAsync(a => a.Id == model.CustomerId);

                    customerdata.IsCompleted = true;
                   _context.Customers.Update(customerdata);
                  await  _context.SaveChangesAsync();

                }
                return new ResponseModel
                {
                    code = ErrorCodes.Successful,
                    data = null,
                    message = string.Empty,
                    success = true,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ResponseModel
                {
                    code = ErrorCodes.Failed,
                    data = null,
                    message = string.Format("{0} -ErrorMessage: {1}", ResponseErrorMessageUtility.OperationFailed, ex.Message),
                    success = false,
                };
            }
        }
        private async Task<bool> SendOTP (VerifyCustomerDto payload)
        {
            try
            {
                var customerdata = await _context.Customers.FirstOrDefaultAsync(a => a.Id == payload.CustomerId);
                if (customerdata !=null)
                {

                    OTP oTP = new()
                    {
                        Token =payload.OTP,
                        Customer = customerdata,
                        IsUsed = false
                    };
                   await _context.OTP.AddAsync(oTP);
                  
                }
                var reponse = await _context.SaveChangesAsync() > 0;
                return reponse;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return false;
            }
        }
    }
}
