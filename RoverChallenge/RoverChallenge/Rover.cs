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

        public Rover(Coordinates currentPosition, DirectionEnum facingDirection)
        {
            CurrentPosition = currentPosition;
            FacingDirection = facingDirection;
        }

        public void IncrementY()
        {
            CurrentPosition.Y++;
        }

        public void DecrementY()
        {
            CurrentPosition.Y--;
        }

        public void IncrementX()
        {
            CurrentPosition.X++;
        }

        public void DecrementX()
        {
            CurrentPosition.X--;
        }
        public void UpdateFacing(DirectionEnum newDirection)
        {
            FacingDirection = newDirection;
        }
        public void UpdateX(int x)
        {
            this.CurrentPosition.X = x;
        }
        public void UpdateY(int y)
        {
            this.CurrentPosition.Y = y;
        }
    }
}
