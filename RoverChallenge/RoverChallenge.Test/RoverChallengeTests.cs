using Microsoft.Extensions.Logging;
using Moq;
using RoverChallenge.Controllers;
using RoverChallenge.Models;
using System;
using Xunit;

namespace RoverChallenge.Test
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("F", "(0,1) N")]
        [InlineData("FB", "(0,0) N")]
        [InlineData("BB", "(0,-2) N")]
        public void Test_MoveRover_FBOnly(string command, string expected)
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var moveRoverRequestModel = new MoveRoverRequestModel()
            {
                StartingPosition = new Coordinates()
                {
                    X = 0,
                    Y = 0,
                },
                FacingDirection = DirectionEnum.N,
                Command = command,
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            Assert.Equal(expected, actual);
        }
    }
}
