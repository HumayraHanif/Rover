using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public class ObstacleDetectedException : Exception
    {
        public ObstacleDetectedException() : base("Obstacle detected") 
        { // empty
        }
    }
}
