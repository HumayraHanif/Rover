using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public interface IGridBoundsChecker
    {
        public bool CheckForNorth(Coordinates currentPosition);
        public bool CheckForEast(Coordinates currentPosition);
        public bool CheckForSouth(Coordinates currentPosition);
        public bool CheckForWest(Coordinates currentPosition);
    }
}
