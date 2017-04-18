using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class UserPlatformAccount
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; } 
        public int PlatformAccountID { get; set; }
        public virtual PlatformAccount PlatformAccount { get; set; }
    }
}
