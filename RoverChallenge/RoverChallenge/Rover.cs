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

        private IObstacleChecker obstacleChecker;

        public Rover(Coordinates currentPosition, DirectionEnum facingDirection, IEnumerable<Coordinates> obstacles)
        {
            CurrentPosition = currentPosition;
            FacingDirection = facingDirection;
            obstacleChecker = new RoverObstacleChecker(obstacles);
        }

        public void IncrementY()
        {
            Coordinates target = new Coordinates()
            {
                X = CurrentPosition.X,
                Y = CurrentPosition.Y + 1,
            };
            CheckForObstacle(target);
            CurrentPosition.Y++;
        }

        public void DecrementY()
        {
            Coordinates target = new Coordinates()
            {
                X = CurrentPosition.X,
                Y = CurrentPosition.Y - 1,
            };
            CheckForObstacle(target);
            CurrentPosition.Y--;
        }

        public void IncrementX()
        {
            Coordinates target = new Coordinates()
            {
                X = CurrentPosition.X + 1,
                Y = CurrentPosition.Y,
            };
            CheckForObstacle(target);
            CurrentPosition.X++;
        }

        public void DecrementX()
        {
            Coordinates target = new Coordinates()
            {
                X = CurrentPosition.X - 1,
                Y = CurrentPosition.Y,
            };
            CheckForObstacle(target);
            CurrentPosition.X--;
        }

        public void UpdateFacing(DirectionEnum newDirection)
        {
            FacingDirection = newDirection;
        }

        public void UpdateX(int x)
        {
            Coordinates target = new Coordinates()
            {
                X = x,
                Y = CurrentPosition.Y,
            };
            CheckForObstacle(target);
            this.CurrentPosition.X = x;
        }
        public void UpdateY(int y)
        {
            Coordinates target = new Coordinates()
            {
                X = CurrentPosition.X,
                Y = y,
            };
            CheckForObstacle(target);
            this.CurrentPosition.Y = y;
        }

        private void CheckForObstacle(Coordinates target)
        {
            if (!obstacleChecker.IsClear(target))
            {
                throw new ObstacleDetectedException();
            }
        }
    }
}
