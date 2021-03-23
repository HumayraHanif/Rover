using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RoverChallengeCommon.Models
{

    public enum CommandStatusEnum
    {
        /// <summary> Status indicating rover landed where expected  </summary>
        Complete,
        /// <summary>Status indicating the rover didn't land as expected because of an obstacle</summary>
        Obstacle,
    }
}
