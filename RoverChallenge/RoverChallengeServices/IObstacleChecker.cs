using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public interface IObstacleChecker
    {
        bool IsClear(Coordinates target);
    }
}
