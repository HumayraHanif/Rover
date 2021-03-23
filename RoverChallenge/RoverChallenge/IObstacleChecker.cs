using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public interface IObstacleChecker
    {
        bool IsClear(Coordinates target);
    }
}
