using CheckNumberPhoneAPI.Services;
using CheckNumberPhoneAPI.Services.Result;
using Microsoft.AspNetCore.Mvc;

namespace CheckNumberPhoneAPI.Controllers
{
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly NumberService _numberServices;

        public NumberController(NumberService numberService) 
        { 
            _numberServices = numberService;
        }



        [HttpPost("check")]
        public async Task<IActionResult> CheckNumber([FromBody] string number)
        {
            var (result, numberPhone) = await _numberServices.AddNumberAsync(number);

            return result switch
            {
                NumberResult.Invalid => BadRequest("Invalid phone number"),
                NumberResult.AlreadyExists => Conflict(),
                NumberResult.Success => Created("", new { phoneNumber = number }),
                _ => StatusCode(500)
            };
        }
    }
}
