using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public class BackwardGridBoundsChecker : IGridBoundsChecker
    {
        private GridDetail gridDetail;
        private IEnumerable<Coordinates> obstacles;

        public BackwardGridBoundsChecker(GridDetail gridDetail)
        {
            this.gridDetail = gridDetail;
            this.obstacles = obstacles;
        }
        public bool CheckForEast(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MinX;
            return result;
        }

        public bool CheckForNorth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MinY;
            return result;
        }

        public bool CheckForSouth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MaxY;
            return result;
        }

        public bool CheckForWest(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MaxX;
            return result;
        }
    }
}
