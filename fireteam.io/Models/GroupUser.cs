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
        public int UserID { get; set; }
        public User User { get; set; }
        public bool IsGroupLeadership { get; set; }
    }
}
