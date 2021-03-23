using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public class RoverObstacleChecker : IObstacleChecker
    {
        private IEnumerable<Coordinates> obstacles;

        public RoverObstacleChecker(IEnumerable<Coordinates> obstacles)
        {
            this.obstacles = (obstacles == null) ? new List<Coordinates>() : obstacles;
        }

        public bool IsClear(Coordinates target)
        {
            var result = !obstacles.Any(obstacle => obstacle.X == target.X && obstacle.Y == target.Y);
            return result;
        }
    }
}
