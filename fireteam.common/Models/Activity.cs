using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Common.Models
{
    public class Activity
    {
        public int ID { get; set; }
        public int AvailableSlots { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string TimeZone { get; set; }
        public bool IsHidden { get; set; }
        public bool IsInviteOnly { get; set; }

        public int ActivityTypeID { get; set; }
        public ActivityType ActivityType{ get;set; }

        public string Description { get; set; }
        public string Requirements { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }

        public int GroupID { get; set; }
        public Group Group { get; set; }

        // This is the activity's organizer
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<User> BootedParticipants { get; set; }
        public ICollection<User> Participants { get; set; }
    }
}
