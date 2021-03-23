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
            if(step == 'F')
            {
                this.rover.IncrementY();
            } 
            else if (step == 'B')
            {
                this.rover.DecrementY();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
