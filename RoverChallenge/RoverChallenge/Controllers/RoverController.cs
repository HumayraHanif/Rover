using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverController : ControllerBase
    {
        private readonly ILogger<RoverController> _logger;

        public RoverController(ILogger<RoverController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string MoveRover([FromBody] MoveRoverRequestModel moveRoverRequestModel)
        {
            var result = string.Empty;

            return result;
        }
    }
}
