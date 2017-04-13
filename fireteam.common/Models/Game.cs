using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Common.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }

        public int PlatformID { get; set; }
        public Platform Platform { get; set; }

        public int GameTypeID { get; set; }
        public GameType GameType { get; set; }
    }
}
