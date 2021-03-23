using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoverChallengeCommon;
using RoverChallengeCommon.Models;
using RoverChallengeServices;
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

        /// <summary>Moves the rover.</summary>
        /// <param name="moveRoverRequestModel">The move rover request model.</param>
        /// <returns> Response indicating the landing coordinates of the rover and the status </returns>
        [HttpPost]
        public RoverMovedResponse MoveRover([FromBody] MoveRoverRequestModel moveRoverRequestModel)
        {
            DirectionEnum direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), moveRoverRequestModel.FacingDirection);
            var rover = new Rover(moveRoverRequestModel.StartingPosition, direction, moveRoverRequestModel.Obstacles);
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
            var landing = roverMover.CurrentPosition();
            var result = new RoverMovedResponse()
            {
                Result = landing,
                Status = roverMover.Status.ToString(),
            };
            return result;
        }
    }
}
