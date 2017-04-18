using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class GroupActivity
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
        public int ActivityID { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
