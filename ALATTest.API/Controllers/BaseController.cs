
using ALATTest.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ALATTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult NotifyModelStateError()
        {
            var erroMesg = new List<string>();
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var msg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                erroMesg.Add(msg);
            }
            ResponseModel response = new();
            response.code = ErrorCodes.Failed;
            response.message = erroMesg.FirstOrDefault();
            response.success = false;
            return BadRequest(response);
        }

        protected new IActionResult Response(ResponseModel result = null)
        {
            if (result.code == ErrorCodes.Successful)
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
