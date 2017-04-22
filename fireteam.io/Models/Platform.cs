using System;

namespace Fireteam.Models
{
    /// <summary>
    /// Represnts the platform of a game
    /// 
    /// e.g., Console, PC, Table-top, etc.
    /// </summary>
    public class Platform
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name for this platform
        /// </summary>
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}