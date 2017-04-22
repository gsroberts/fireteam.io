using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class GroupUser
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public bool IsGroupLeadership { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
