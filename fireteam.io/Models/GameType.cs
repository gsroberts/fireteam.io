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

        /// <summary>
        /// Gets or sets a boolean flag that represents whether or 
        /// not this game is a console game
        /// </summary>
        public bool IsConsoleGame { get; set; }
        
        /// <summary>
        /// Gets or sets the console model ID for this game if applicable
        /// </summary>
        public int ConsoleModelID { get; set; }

        /// <summary>
        /// Gets or sets the console model for this game if applicable
        /// </summary>
        public ConsoleModel ConsoleModel { get; set; }
    }
}