using Martian_Robots.Dtos;
using Martian_Robots.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Martian_Robots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainGameController : ControllerBase
    {
        private readonly ILogger<MainGameController> _logger;
        private readonly IMainGameService _mainGameService;

        public MainGameController(ILogger<MainGameController> logger,
            IMainGameService mainGameService)
        {
            _logger = logger;
            _mainGameService = mainGameService;
        }

        [HttpPost("input/parameter")]
        public ActionResult<StringDto> inputMethodParameter(string input)
        {
            try
            {
                var res = _mainGameService.inputMethod(input);
                return Ok(new StringDto(res));
            }
            catch (Exception e)
            {
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }
        [HttpPost("input/JSON")]
        public ActionResult<StringDto> inputMethodJSON(StringDto input)
        {
            try
            {
                var res = _mainGameService.inputMethod(input.result);
                return Ok(new StringDto(res));
            }
            catch (Exception e)
            {
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }
    }
}
