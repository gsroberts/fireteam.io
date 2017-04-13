namespace Fireteam.Common.Models
{
    public class PlatformAccount
    {
        public int ID { get; set; }
        public string GamerTag { get; set; }

        public int PlatformID { get; set; }
        public Platform Platform { get; set; }

        public int ConsoleModelID { get; set; }
        public ConsoleModel ConsoleModel { get; set; }
    }
}