using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public class ForwardGridBoundsChecker : IGridBoundsChecker
    {
        private GridDetail gridDetail;

        public ForwardGridBoundsChecker(GridDetail gridDetail)
        {
            this.gridDetail = gridDetail;
        }

        /// <summary>Checks whether grid boundary will be crossed when rover is facing east and will move forwards</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForEast(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MaxX;
            return result;
        }

        /// <summary>Checks to see if grid boundary will be crossed when rover is facing north and will move forwards</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForNorth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MaxY;
            return result;
        }

        /// <summary>Checks to see whether the grid boundary will be crossed when the rover is facing south and will move forward</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForSouth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MinY;
            return result;
        }

        /// <summary>Checks whether a grid boundary will be crossed when the rover is facing west and will move forwards.</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForWest(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MinX;
            return result;
        }
    }
}
