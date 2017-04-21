using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fireteam.Models
{
    public class GamePlatform
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        [ForeignKey("GameID")]
        public virtual Game Game { get; set; }
        public int PlatformID { get; set; }
        [ForeignKey("PlatformID")]
        public virtual Platform Platform { get; set; }
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
