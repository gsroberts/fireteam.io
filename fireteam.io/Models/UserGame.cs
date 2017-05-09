using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class UserGame
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public virtual User User { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
