using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge.Models
{
    public class MoveRoverRequestModel
    {
        public Coordinates StartingPosition { get; set; }
        public DirectionEnum FacingDirection { get; set; }
        public string Command { get; set; }
    }
}
