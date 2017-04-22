using System;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace Fireteam.Models
{
    /// <summary>
    /// Represents the console model for games and activities that are
    /// console based
    /// </summary>
    public class ConsoleModel
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name for this console model
        /// 
        /// e.g., XBox 360, PS4, PS Vita
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer for this console model
        /// 
        /// e.g., Sony, Microsoft, Ninetendo
        /// </summary>
        public string Manufacturer { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}