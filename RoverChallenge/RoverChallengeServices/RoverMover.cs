using RoverChallengeCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeServices
{
    public class RoverMover
    {

        public CommandStatusEnum Status { get; private set; }

        private Rover rover;
        private char[] commands;
        private GridDetail gridDetail;
        private IGridBoundsChecker forwardGridBoundsChecker;
        private IGridBoundsChecker backwardGridBoundsChecker;

        public RoverMover(Rover rover, string command, GridDetail gridDetail)
        {
            this.rover = rover;
            this.commands = command.ToCharArray();
            this.gridDetail = gridDetail;
            this.forwardGridBoundsChecker = new ForwardGridBoundsChecker(gridDetail);
            this.backwardGridBoundsChecker = new BackwardGridBoundsChecker(gridDetail);
            Status = CommandStatusEnum.Complete; // or in progress
        }

        /// <summary>Moves the rover.</summary>
        public void MoveRover()
        {
            foreach (char step in commands)
            {
                try
                {
                    MoveRoverStep(step);
                }
                catch (ObstacleDetectedException)
                {
                    this.Status = CommandStatusEnum.Obstacle;
                    return;
                }
                
            }
        }

        /// <summary>Gets the current position of the rover</summary>
        /// <returns>The current position of the rover</returns>
        public string CurrentPosition()
        {
            var result = $"({rover.CurrentPosition.X},{rover.CurrentPosition.Y}) {rover.FacingDirection.ToString()}";
            return result;
        }

        /// <summary>Moves the rover according to the given step.</summary>
        /// <param name="step">The step.</param>
        /// <exception cref="System.NotImplementedException">If an unsupported character is entered</exception>
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
                    if (forwardGridBoundsChecker.CheckForNorth(rover.CurrentPosition))
                    {
                        rover.IncrementY();
                    }
                    else
                    {
                        rover.UpdateY(gridDetail.MinY);
                    }                   
                    break;
                case DirectionEnum.S:
                    if (forwardGridBoundsChecker.CheckForSouth(rover.CurrentPosition))
                    {
                        rover.DecrementY();
                    }
                    else
                    {
                        rover.UpdateY(gridDetail.MaxY);
                    }                   
                    break;
                case DirectionEnum.E:
                    if (forwardGridBoundsChecker.CheckForEast(rover.CurrentPosition))
                    {
                        rover.IncrementX();
                    }
                    else
                    {
                        rover.UpdateX(gridDetail.MinX);
                    }                   
                    break;
                case DirectionEnum.W:
                    if (forwardGridBoundsChecker.CheckForWest(rover.CurrentPosition))
                    {
                        rover.DecrementX();
                    }
                    else
                    {
                        rover.UpdateX(gridDetail.MaxX);
                    }                    
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
                    if (backwardGridBoundsChecker.CheckForNorth(rover.CurrentPosition))
                    {
                        rover.DecrementY();
                    }
                    else
                    {
                        rover.UpdateY(gridDetail.MaxY);
                    }                      
                    break;
                case DirectionEnum.S:
                    if (backwardGridBoundsChecker.CheckForSouth(rover.CurrentPosition))
                    {
                        rover.IncrementY();
                    }
                    else
                    {
                        rover.UpdateY(gridDetail.MinY);
                    }
                        
                    break;
                case DirectionEnum.E:
                    if (backwardGridBoundsChecker.CheckForEast(rover.CurrentPosition))
                    {
                        rover.DecrementX();
                    }
                    else
                    {
                        rover.UpdateX(gridDetail.MaxX);
                    }
                        
                    break;
                case DirectionEnum.W:
                    if (backwardGridBoundsChecker.CheckForWest(rover.CurrentPosition))
                    {
                        rover.IncrementX();
                    }
                    else
                    {
                        rover.UpdateX(gridDetail.MinX);
                    }
                        
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
