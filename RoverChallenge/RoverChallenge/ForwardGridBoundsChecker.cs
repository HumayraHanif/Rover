using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public class ForwardGridBoundsChecker : IGridBoundsChecker
    {
        private GridDetail gridDetail;

        public ForwardGridBoundsChecker(GridDetail gridDetail)
        {
            this.gridDetail = gridDetail;
        }

        public bool CheckForEast(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MaxX;
            return result;
        }

        public bool CheckForNorth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MaxY;
            return result;
        }

        public bool CheckForSouth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MinY;
            return result;
        }

        public bool CheckForWest(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MinX;
            return result;
        }
    }
}
