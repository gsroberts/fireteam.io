using System.Diagnostics.Tracing;

namespace Fireteam.Models
{
    public enum BootReasons
    {
        None = 0,
        Unfriendly = 1,
        Unhelpful = 2,
        TeammateConflict = 3,
        NoShow = 4,
        TentativePlayerConfirmed = 5,
        Other = 6
    }
}