using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fireteam.Models
{
    public class GamePlatform
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int PlatformID { get; set; }
    }
}
