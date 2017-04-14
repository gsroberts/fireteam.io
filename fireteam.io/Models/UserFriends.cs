using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class UserFriends
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("FriendID")]
        public User Friend { get; set; }
        public bool CanAddToActivities { get; set; }
    }
}
