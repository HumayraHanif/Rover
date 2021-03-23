using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
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

        /// <summary>Increments y by 1.</summary>
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

        /// <summary>Decrements y by 1.</summary>
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

        /// <summary>Increments x by 1.</summary>
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

        /// <summary>Decrements x by 1.</summary>
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

        /// <summary>Updates the facing direction of the rover.</summary>
        /// <param name="newDirection">The new direction.</param>
        public void UpdateFacing(DirectionEnum newDirection)
        {
            FacingDirection = newDirection;
        }

        /// <summary>Updates the x coordinate value.</summary>
        /// <param name="x">The new x coordinate value.</param>
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
        /// <summary>Updates the y value coordinate.</summary>
        /// <param name="y">The y value coordinate</param>
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
