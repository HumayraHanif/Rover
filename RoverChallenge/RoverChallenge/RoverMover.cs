using RoverChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge
{
    public class RoverMover
    {
        private Rover rover;
        private char[] commands;

        public RoverMover(Rover rover, string command)
        {
            this.rover = rover;
            this.commands = command.ToCharArray();
        }

        public void MoveRover()
        {
            foreach (char step in commands)
            {
                MoveRoverStep(step);
            }
        }

        public string CurrentPosition()
        {
            var result = $"({rover.CurrentPosition.X},{rover.CurrentPosition.Y}) {rover.FacingDirection.ToString()}";
            return result;
        }

        private void MoveRoverStep(char step)
        {
            if (step == 'F')
            {
                MoveRoverForward();
            }
            else if (step == 'B')
            {
                MoveRoverBack();
            }
            else if (step == 'L')
            {
                MoveRoverLeft();
            }
            else if (step == 'R')
            {
                MoveRoverRight();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void MoveRoverForward()
        {
            switch (rover.FacingDirection)
            {
                case DirectionEnum.N:
                    rover.IncrementY();
                    break;
                case DirectionEnum.S:
                    rover.DecrementY();
                    break;
                case DirectionEnum.E:
                    rover.IncrementX();
                    break;
                case DirectionEnum.W:
                    rover.DecrementX();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void MoveRoverBack()
        {
            switch (rover.FacingDirection)
            {
                case DirectionEnum.N:
                    rover.DecrementY();
                    break;
                case DirectionEnum.S:
                    rover.IncrementY();
                    break;
                case DirectionEnum.E:
                    rover.DecrementX();
                    break;
                case DirectionEnum.W:
                    rover.IncrementX();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void MoveRoverLeft()
        {
            switch (rover.FacingDirection)
            {
                case DirectionEnum.N:
                    rover.UpdateFacing(DirectionEnum.W);
                    break;
                case DirectionEnum.S:
                    rover.UpdateFacing(DirectionEnum.E);
                    break;
                case DirectionEnum.E:
                    rover.UpdateFacing(DirectionEnum.N);
                    break;
                case DirectionEnum.W:
                    rover.UpdateFacing(DirectionEnum.S);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void MoveRoverRight()
        {
            switch (rover.FacingDirection)
            {
                case DirectionEnum.N:
                    rover.UpdateFacing(DirectionEnum.E);
                    break;
                case DirectionEnum.S:
                    rover.UpdateFacing(DirectionEnum.W);
                    break;
                case DirectionEnum.E:
                    rover.UpdateFacing(DirectionEnum.S);
                    break;
                case DirectionEnum.W:
                    rover.UpdateFacing(DirectionEnum.N);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
