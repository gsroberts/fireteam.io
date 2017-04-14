using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace Fireteam.Models
{
    /// <summary>
    /// Represents the type of activity that a given activity is 
    /// </summary>
    public class ActivityType
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets this activity type's name
        /// 
        /// e.g., Quest, Misson, Bounty
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for this activity type
        /// </summary>
        public string Description { get; set; }
    }
}