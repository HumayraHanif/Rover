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
            var rover = new Rover(moveRoverRequestModel.StartingPosition, moveRoverRequestModel.FacingDirection);
            var maxX = (moveRoverRequestModel.GridDimensions != null) ? (moveRoverRequestModel.GridDimensions.X / 2) : 10;
            var maxY = (moveRoverRequestModel.GridDimensions != null) ? (moveRoverRequestModel.GridDimensions.Y / 2) : 10;
            var gridDetail = new GridDetail()
            {
                MaxX = maxX,
                MinX = maxX *-1,
                MaxY = maxY,
                MinY = maxY * -1,
            };
            var roverMover = new RoverMover(rover, moveRoverRequestModel.Command, gridDetail);
            roverMover.MoveRover();
            var result = roverMover.CurrentPosition();
            return result;
        }
    }
}
