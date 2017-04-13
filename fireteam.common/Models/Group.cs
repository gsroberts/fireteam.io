using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Common.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GroupType { get; set; }
        public bool IsHidden { get; set; }
        public bool IsInviteOnly { get; set; }

        public ICollection<User> Leaders { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
