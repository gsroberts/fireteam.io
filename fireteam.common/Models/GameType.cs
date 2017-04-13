namespace Fireteam.Common.Models
{
    public class GameType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsConsoleGame { get; set; }
        
        public int ConsoleModelID { get; set; }
        public ConsoleModel ConsoleModel { get; set; }
    }
}