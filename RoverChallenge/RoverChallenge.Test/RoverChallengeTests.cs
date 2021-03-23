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
                FacingDirection = DirectionEnum.N,
                Command = command,
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            Assert.Equal(expected, actual);
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
                FacingDirection = DirectionEnum.N,
                Command = command,
                GridDimensions = new Coordinates()
                {
                    X = 10,
                    Y = 10,
                }
            };
            var actual = roverController.MoveRover(moveRoverRequestModel);
            Assert.Equal(expected, actual);
        }
    }
}
