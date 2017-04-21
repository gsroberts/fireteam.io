using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class ActivityUser
    {
        public int ID { get; set; }
        public int ActivityID { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public bool IsTentative { get; set; }
        public bool IsAlternate { get; set; }
        public bool HasBeenBooted { get; set; }
        public int ReasonForBoot { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
