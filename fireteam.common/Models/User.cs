using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fireteam.Common.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TimeZone { get; set; }
        public bool CanShowInSearches { get; set; }

        public ICollection<User> BlockedUsers { get; set; }

        public ICollection<PlatformAccount> PlatformAccounts { get; set; }
        
        public ICollection<Group> Groups { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<User> Friends { get; set; }
    }          
}
