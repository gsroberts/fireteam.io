using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class GroupGame
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
