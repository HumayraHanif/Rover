using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoverChallengeCommon.Models
{
    public class RoverMovedResponse
    {
        /// <summary>Gets or sets the result of the landing place of the rover.</summary>
        /// <value>The position of the rover.</value>
        public string Result { get; set; }
        /// <summary>Gets or sets the status.</summary>
        /// <value>The status.</value>
        public string Status { get; set; }
    }
}
