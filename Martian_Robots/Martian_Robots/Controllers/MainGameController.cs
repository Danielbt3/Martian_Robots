using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Martian_Robots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainGameController : ControllerBase
    {
        private readonly ILogger<MainGameController> _logger;

        public MainGameController(ILogger<MainGameController> logger)
        {
            _logger = logger;
        }
    }
}
