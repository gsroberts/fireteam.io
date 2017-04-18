﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Models
{
    /// <summary>
    /// This class represents a group of users within fireteam.io
    /// </summary>
    public class Group
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of this group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of this group
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the group type ID of this group
        /// </summary>
        public int GroupTypeID { get; set; }

        /// <summary>
        /// Gets or sets the group type of this group
        /// </summary>
        public GroupType GroupType { get; set; }

        /// <summary>
        /// Gets or sets the a boolean representing whether or not this
        /// group and it's activity is hidden from searches
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets a boolean representing whether or not this group
        /// is invite only
        /// </summary>
        public bool IsInviteOnly { get; set; }

        /// <summary>
        /// Gets or sets a list of the members of this group
        /// </summary>
        public virtual ICollection<GroupUser> Members { get; set; }

        /// <summary>
        /// Gets or sets a list of games for this group
        /// </summary>
        public virtual ICollection<GroupGame> Games { get; set; }

        /// <summary>
        /// Gets or sets a list of platforms for this group
        /// </summary>
        public virtual ICollection<GroupPlatform> Platforms { get; set; }

        /// <summary>
        /// Gets or sets a list of activities for this group
        /// </summary>
        public virtual ICollection<GroupActivity> Activities { get; set; }
    }
}
