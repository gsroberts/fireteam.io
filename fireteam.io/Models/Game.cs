using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Models
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

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a boolean flag that represents whether or 
        /// not this game is a console game
        /// </summary>
        public bool IsConsoleGame { get; set; }

        /// <summary>
        /// The platforms for which this game is available
        /// </summary>
        public virtual ICollection<GamePlatform> Platforms { get; set; }

        /// <summary>
        /// Gets or sets the console model for this game if applicable
        /// </summary>
        public virtual ICollection<ConsoleModel> ConsoleModels { get; set; }
    }
}
