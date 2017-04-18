using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class UserFriend
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("FriendID")]
        public User Friend { get; set; }
        public bool CanAddToActivities { get; set; }
    }
}
