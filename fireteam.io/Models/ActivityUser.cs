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
        public int UserID { get; set; }
        public User User { get; set; }
        public bool IsTentative { get; set; }
        public bool HasBeenBooted { get; set; }
        public bool ReasonForBoot { get; set; }
    }
}
