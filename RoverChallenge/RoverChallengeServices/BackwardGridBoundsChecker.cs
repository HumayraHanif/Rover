using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public class BackwardGridBoundsChecker : IGridBoundsChecker
    {
        private GridDetail gridDetail;

        public BackwardGridBoundsChecker(GridDetail gridDetail)
        {
            this.gridDetail = gridDetail;
        }
        /// <summary>Checks if bound will be crossed when rover is facing east and will move backwards.</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForEast(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MinX;
            return result;
        }

        /// <summary>Checks if grid boundary will be crossed when rover is facing north and will go backwards</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForNorth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MinY;
            return result;
        }

        /// <summary>Checks to see if grid boundary will be crossed when rover is racing south and will go backwards.</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForSouth(Coordinates currentPosition)
        {
            var result = currentPosition.Y != gridDetail.MaxY;
            return result;
        }

        /// <summary>Checks whether grid boundary will be crossed when rover is facing west and will go backwards</summary>
        /// <param name="currentPosition">The current position.</param>
        /// <returns>True if boundary won't be crossed, false otherwise</returns>
        public bool CheckForWest(Coordinates currentPosition)
        {
            var result = currentPosition.X != gridDetail.MaxX;
            return result;
        }
    }
}
