using System;

namespace Fireteam.Models
{
    /// <summary>
    /// Represnts a group's type
    /// 
    /// e.g., Clan, Guild, etc.
    /// </summary>
    public class GroupType
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name for this group type
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description for this group type
        /// </summary>
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}