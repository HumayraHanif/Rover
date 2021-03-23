using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public class RoverObstacleChecker : IObstacleChecker
    {
        private IEnumerable<Coordinates> obstacles;

        public RoverObstacleChecker(IEnumerable<Coordinates> obstacles)
        {
            this.obstacles = (obstacles == null) ? new List<Coordinates>() : obstacles;
        }

        /// <summary>Determines whether the specified target coordinate is clea from obstacles.</summary>
        /// <param name="target">The target coordinate.</param>
        /// <returns>
        ///   <c>true</c> if the specified target is clear; otherwise, <c>false</c>.</returns>
        public bool IsClear(Coordinates target)
        {
            var result = !obstacles.Any(obstacle => obstacle.X == target.X && obstacle.Y == target.Y);
            return result;
        }
    }
}
