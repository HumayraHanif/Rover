using Microsoft.Extensions.Logging;
using Moq;
using RoverChallenge.Controllers;
using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace RoverChallenge.Test
{
    public class UnitTest1
    {

        [Theory]
        [InlineData("F", "(0,1) N")]
        [InlineData("FB", "(0,0) N")]
        [InlineData("BB", "(0,-2) N")]
        [InlineData("FFRFF", "(2,2) E")]
        [InlineData("LLLL", "(0,0) N")]
        [InlineData("RR", "(0,0) S")]
        [InlineData("RRF", "(0,-1) S")]
        [InlineData("RRFB", "(0,0) S")]
        [InlineData("LFBR", "(0,0) N")]
        [InlineData("RRRR", "(0,0) N")]
        [InlineData("RFBR", "(0,0) S")]
        public void Test_MoveRover_FromOrigin(string command, string expected)
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
                FacingDirection = DirectionEnum.N.ToString(),
                Command = command,
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            var expectedResponse = new RoverMovedResponse()
            {
                Result = expected,
                Status = CommandStatusEnum.Complete.ToString(),
            };
            Assert.Equal(expectedResponse.Result, actual.Result);
            Assert.Equal(expectedResponse.Status, actual.Status);
        }

        [Theory]
        [InlineData("RFFFFFF", "(-5,0) E", 0, 0)]
        [InlineData("RBLF", "(4,-5) N", 5, 5)]
        [InlineData("FFRRFF", "(0,0) S", 0, 0)]
        [InlineData("LLFF", "(4,4) S", 4, -5)]
        [InlineData("LFR", "(5,-1) N", -5, -1)]
        [InlineData("RB", "(5,-5) E", -5, -5)]
        [InlineData("LBRBB", "(-5,5) N", 5, -4)]
        [InlineData("BBL", "(5,4) W", 5, -5)]
        public void Test_MoveRover_On5x5_Wrapping(string command, string expected, int startingX, int startingY)
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var moveRoverRequestModel = new MoveRoverRequestModel()
            {
                StartingPosition = new Coordinates()
                {
                    X = startingX,
                    Y = startingY,
                },
                FacingDirection = DirectionEnum.N.ToString(),
                Command = command,
                GridDimensions = new Coordinates()
                {
                    X = 10,
                    Y = 10,
                }
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            var expectedResponse = new RoverMovedResponse()
            {
                Result = expected,
                Status = CommandStatusEnum.Complete.ToString(),
            };
            Assert.Equal(expectedResponse.Result, actual.Result);
            Assert.Equal(expectedResponse.Status, actual.Status);
        }

        [Theory]
        [InlineData("RFFFFFF", "(2,0) E", 0, 0)]
        [InlineData("LF", "(-1,0) W", -1, 0)]
        [InlineData("BBB", "(4,-2) N", 4, 0)]
        [InlineData("RRBB", "(0,-2) S", 0, -3)]
        public void Test_MoveRover_Obstacle(string command, string expected, int startingX, int startingY)
        {
            IEnumerable<Coordinates> obstacles = new List<Coordinates>() {
                new Coordinates() { X = 3, Y = 0 },
                new Coordinates() { X = -2, Y = 0 },
                new Coordinates() { X = 4, Y = -3 },
                new Coordinates() { X = 0, Y = -1 },
            };

            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var moveRoverRequestModel = new MoveRoverRequestModel()
            {
                StartingPosition = new Coordinates()
                {
                    X = startingX,
                    Y = startingY,
                },
                FacingDirection = DirectionEnum.N.ToString(),
                Command = command,
                GridDimensions = new Coordinates()
                {
                    X = 10,
                    Y = 10,
                },
                Obstacles = obstacles,
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            var expectedResponse = new RoverMovedResponse()
            {
                Result = expected,
                Status = CommandStatusEnum.Obstacle.ToString(),
            };
            Assert.Equal(expectedResponse.Status, actual.Status);
            Assert.Equal(expectedResponse.Result, actual.Result);
        }
    }
}
