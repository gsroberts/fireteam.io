using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Common.Models
{
    /// <summary>
    /// Represents a given game title
    /// </summary>
    public class Game
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title of this game
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the publisher of this game title
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the description for this game title
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the game type ID for this game title
        /// </summary>
        public int GameTypeID { get; set; }

        /// <summary>
        /// Gets or sets the game type for this game title
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        /// The platforms for which this game is available
        /// </summary>
        public ICollection<Platform> Platforms { get; set; }
    }
}
