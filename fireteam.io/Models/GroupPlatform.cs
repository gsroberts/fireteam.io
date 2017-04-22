using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class GroupPlatform
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
        public int PlatformID { get; set; }
        public virtual Platform Platform { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
