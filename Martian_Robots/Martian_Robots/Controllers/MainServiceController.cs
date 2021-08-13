using Martian_Robots.Dtos;
using Martian_Robots.Services.Auxiliary;
using Martian_Robots.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Martian_Robots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainServiceController : ControllerBase
    {
        private readonly ILogger<MainServiceController> _logger;
        private readonly IMainService _mainGameService;

        public MainServiceController(ILogger<MainServiceController> logger,
            IMainService mainGameService)
        {
            _logger = logger;
            _mainGameService = mainGameService;
        }

        [HttpPost("input/parameter")]
        public ActionResult<StringDto> inputMethodParameter(string input)
        {
            try
            {
                _logger.LogInformation("START inputMethodParameter IP: " + Utilities.GetIpValue(Request));
                var res = _mainGameService.inputMethod(input);
                _logger.LogInformation("END inputMethodParameter IP: " + Utilities.GetIpValue(Request));
                return Ok(new StringDto(res));
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR inputMethodParameter IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }

        [HttpPost("input/JSON")]
        public ActionResult<StringDto> inputMethodJSON(StringDto input)
        {
            try
            {
                _logger.LogInformation("START inputMethodJSON IP: " + Utilities.GetIpValue(Request));
                var res = _mainGameService.inputMethod(input.result);
                _logger.LogInformation("END inputMethodJSON IP: " + Utilities.GetIpValue(Request));
                return Ok(new StringDto(res));
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR inputMethodJSON IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }
    }
}