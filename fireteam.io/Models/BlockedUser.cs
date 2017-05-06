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

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User UserBeingBlocked { get; set; }

        public string BlockingUserID { get; set; }
        [ForeignKey("BlockingUserID")]
        public virtual User BlockingUser { get; set; }

        public int? BlockingGroupID { get; set; }
        [ForeignKey("BlockingGroupID")]
        public virtual Group Group { get; set; }

        public int? ActivityID { get; set; }
        public virtual Activity Activity { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
