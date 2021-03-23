using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeCommon.Models
{
    public class MoveRoverRequestModel
    {
        /// <summary>Gets or sets the starting position of the rover.</summary>
        /// <value>The starting position.</value>
        public Coordinates StartingPosition { get; set; }
        /// <summary>Gets or sets the direction the rover is facing.</summary>
        /// <value>The facing direction of the rover. Can be N, E, S, W only</value>
        public string FacingDirection { get; set; }
        /// <summary>Gets or sets the command to move the rover.</summary>
        /// <value>The command the rover will use to move.</value>
        public string Command { get; set; }
        /// <summary>Gets or sets the grid dimensions.</summary>
        /// <value>The grid dimensions.</value>
        public Coordinates GridDimensions { get; set; }
        /// <summary>Gets or sets the obstacles (if any).</summary>
        /// <value>The obstacles.</value>
        public IEnumerable<Coordinates> Obstacles { get; set; }
    }
}
