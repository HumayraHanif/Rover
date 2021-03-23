using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public class Rover
    {
        public Coordinates CurrentPosition { get; private set; }
        public DirectionEnum FacingDirection { get; private set; }

        public Rover(Coordinates currentPosition)
        {
            CurrentPosition = currentPosition;
            FacingDirection = DirectionEnum.N;
        }

        public void IncrementY()
        {
            CurrentPosition.Y++;
        }
        public void DecrementY()
        {
            CurrentPosition.Y--;
        }
    }
}
