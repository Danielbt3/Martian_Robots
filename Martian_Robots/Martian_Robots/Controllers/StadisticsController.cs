using Martian_Robots.Dtos;
using Martian_Robots.Services.Auxiliary;
using Martian_Robots.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Martian_Robots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StadisticsController : ControllerBase
    {
        private readonly ILogger<StadisticsController> _logger;
        private readonly IStadisticsService _stadisticsService;

        public StadisticsController(ILogger<StadisticsController> logger,
            IStadisticsService stadisticsService)
        {
            _logger = logger;
            _stadisticsService = stadisticsService;
        }

        [HttpGet("query/robots")]
        public ActionResult<List<RobotLogDto>> GetRobotLogs(int maxItemsPerPage = 10, int skip = 0)
        {
            try
            {
                _logger.LogInformation("START GetRobotLogs IP: " + Utilities.GetIpValue(Request));
                var res = _stadisticsService.GetRobotLogs(maxItemsPerPage, skip);
                _logger.LogInformation("END GetRobotLogs IP: " + Utilities.GetIpValue(Request));
                return res;
            }
            catch (Exception e)
            {
                _logger.LogError("ERROR GetRobotLogs IP: " + Utilities.GetIpValue(Request) + " Error : " + e.StackTrace);
                return new ObjectResult(new { status = "Error", message = $"{e.Message}" });
            }
        }
    }
}