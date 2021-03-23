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

        [Fact]
        public void Test_MoveRover_F()
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var expected = "(0,1) N";
            var moveRoverRequestModel = new MoveRoverRequestModel()
            {
                StartingPosition = new Coordinates()
                {
                    X = 0,
                    Y = 0,
                },
                FacingDirection = DirectionEnum.N,
                Command = "F"
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_MoveRoverForward_FB()
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var expected = "(0,0) N";
            var moveRoverRequestModel = new MoveRoverRequestModel()
            {
                StartingPosition = new Coordinates()
                {
                    X = 0,
                    Y = 0,
                },
                FacingDirection = DirectionEnum.N,
                Command = "FB"
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_MoveRoverForward_BB()
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var expected = "(0, -2) N";
            var moveRoverRequestModel = new MoveRoverRequestModel()
            {
                StartingPosition = new Coordinates()
                {
                    X = 0,
                    Y = 0,
                },
                FacingDirection = DirectionEnum.N,
                Command = "BB"
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            Assert.Equal(expected, actual);
        }
    }
}
