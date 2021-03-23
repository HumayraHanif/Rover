using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallenge.Models
{
    public class RoverMovedResponse
    {
        public string Result { get; set; }
        public CommandStatus Status { get; set; }
    }
}
