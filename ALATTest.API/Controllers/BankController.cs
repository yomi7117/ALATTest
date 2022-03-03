using ALATTest.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ALATTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : BaseController
    {
        private readonly IBank _bank;
        private readonly ILogger<BankController> _logger;

        public BankController(IBank bank, ILogger<BankController> logger)
        {
            _bank = bank;
            _logger = logger;
        }
        [HttpGet]
        [Route("getbanks")]
        public async Task<IActionResult> GetBanks()
        {
            var result = await _bank.GetAllBanks();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
