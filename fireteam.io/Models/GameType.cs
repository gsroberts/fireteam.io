using System;
using System.Collections.Generic;

namespace Fireteam.Models
{
    /// <summary>
    /// Represents the type of a game a specific title is
    /// 
    /// e.g., FPS, RPG, MMORPG, Tabletop, Card, etc
    /// </summary>
    public class GameType
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name for this game type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for this game type
        /// </summary>
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}