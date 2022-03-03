using ALATTest.Domain.DTO;
using ALATTest.Repository.Interface;
using ALATTest.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ALATTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomer _customer;

        public CustomerController(ICustomer  customer, ILogger<CustomerController> logger)
        {
            _logger = logger;
            _customer = customer;
        }

        [HttpPost]
        [Route("createcustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = await _customer.AddCustomer(model);
            if (result.success == false)
            {
                return BadRequest(new { success = false, error = result });
            }
            else
            {
                return Ok(new { success = true, message = result.message });
            }
        }
        [HttpGet]
        [Route("getcustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = await _customer.GetAllCustomer();
            if (result.code == ErrorCodes.Successful)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost]
        [Route("verifycustomer")]
        public async Task<IActionResult> VerifyCustomer([FromBody] VerifyCustomerDto model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateError();
            }

            var result = await _customer.VerifyCustomer(model);
            if (result.success == false)
            {
                return BadRequest(new { success = false, error = result });
            }
            else
            {
                return Ok(new { success = true, message = result.message });
            }
        }
    }
}
