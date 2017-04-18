using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class BlockedUser
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public int? BlockingUserID { get; set; }
        [ForeignKey("BlockingUserID")]
        public virtual User BlockingUser { get; set; }

        public int? BlockingGroupID { get; set; }
        [ForeignKey("BlockingGroupID")]
        public virtual Group Group { get; set; }

        public int? ActivityID { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
