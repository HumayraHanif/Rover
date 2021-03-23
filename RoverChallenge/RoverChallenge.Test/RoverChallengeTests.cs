using Microsoft.Extensions.Logging;
using Moq;
using RoverChallenge.Controllers;
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
            var actual = roverController.MoveRover("F");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_MoveRoverForward_FB()
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var expected = "(0,0) N";
            var actual = roverController.MoveRover("FB");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_MoveRoverForward_BB()
        {
            Mock<ILogger<RoverController>> mockLogger = new Mock<ILogger<RoverController>>();
            RoverController roverController = new RoverController(mockLogger.Object);
            var expected = "(0, -2) N";
            var actual = roverController.MoveRover("BB");
            Assert.Equal(expected, actual);
        }
    }
}
