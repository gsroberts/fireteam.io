using System;

namespace Fireteam.Models
{
    /// <summary>
    /// Represents a user's account for a specific platform
    /// 
    /// e.g., the user's PSN or XBox Live IDs
    /// </summary>
    public class PlatformAccount
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the user's gamertag on this platform
        /// </summary>
        public string GamerTag { get; set; }

        /// <summary>
        /// Gets or sets the plaftorm ID for this account
        /// </summary>
        public int PlatformID { get; set; }

        /// <summary>
        /// Gets or sets the platform for this account
        /// </summary>
        public virtual Platform Platform { get; set; }

        /// <summary>
        /// Gets or sets the console model ID for this account, if provided
        /// 
        /// e.g., XBox 360, PS4, PS Vita
        /// </summary>
        public int? ConsoleModelID { get; set; }

        /// <summary>
        /// Gets or sets the console model for this account, if provided
        /// </summary>
        public virtual ConsoleModel ConsoleModel { get; set; }

        public string UserID { get; set; }

        public virtual User User { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}