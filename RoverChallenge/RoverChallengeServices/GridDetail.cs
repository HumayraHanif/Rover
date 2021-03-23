using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public class GridDetail
    {
        /// <summary>Gets or sets the maximum x value within a grid.</summary>
        /// <value>The maximum x.</value>
        public int MaxX { get; set; }
        /// <summary>Gets or sets the maximum y value within a grid.</summary>
        /// <value>The maximum y value.</value>
        public int MaxY { get; set; }
        /// <summary>Gets or sets the minimum x value within a grid.</summary>
        /// <value>The minimum x value within a grid.</value>
        public int MinX { get; set; }
        /// <summary>Gets or sets the minimum y value within the grid.</summary>
        /// <value>The minimum y value.</value>
        public int MinY { get; set; }
    }
}
