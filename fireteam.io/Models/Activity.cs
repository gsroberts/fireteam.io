using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Models
{
    /// <summary>
    /// This class represents a group activity that is being organized through the
    /// fireteam.io service.
    /// </summary>
    public class Activity
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the number of slots available for this activity
        /// 
        /// The number of actual slots is this number minus the number of
        /// participants
        /// </summary>
        public int AvailableSlots { get; set; }

        /// <summary>
        /// Gets or sets the activity's start time in UTC format
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the activity's duration
        /// 
        /// Create a TimeSpan object from user input and use the string
        /// representation for this field
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the time zone ID for this activity
        /// 
        /// This is used to translate the times to user-local
        /// representations
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets a boolean representing whether or not this
        /// activity is public and can show up in searches
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets a boolean representing whether or not this 
        /// activity can be freely joined and if the user must request
        /// the organizer allow them to join
        /// </summary>
        public bool IsInviteOnly { get; set; }

        /// <summary>
        /// Gets or sets the activity type ID for this activity
        /// </summary>
        public int ActivityTypeID { get; set; }

        /// <summary>
        /// Gets or sets the activity type for this activity
        /// </summary>
        public ActivityType ActivityType{ get;set; }

        /// <summary>
        /// Gets or sets the description for this activity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the requirements for this activity
        /// 
        /// i.e., weapons loadouts, level, other requirements
        /// </summary>
        public string Requirements { get; set; }

        /// <summary>
        /// Gets or sets the game ID for this activity
        /// </summary>
        public int GameID { get; set; }

        /// <summary>
        /// Gets or sets the game for this activity
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets the group ID for this activity, if one exists
        /// </summary>
        public int? GroupID { get; set; }

        /// <summary>
        /// Gets or sets the group for this activity, if one exists
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user that is this activity's
        /// organizer
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user that is this activity's organizer
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets a collection of participants for this
        /// activity
        /// </summary>
        public ICollection<ActivityUser> Participants { get; set; }
    }
}
