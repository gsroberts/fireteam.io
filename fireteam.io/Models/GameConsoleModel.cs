using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class GameConsoleModel
    {
        public int ID { get; set; }
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public int ConsoleModelID { get; set; }

        [ForeignKey("ConsoleModelID")]
        public ConsoleModel ConsoleModel { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
