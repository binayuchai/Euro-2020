using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
    public class Squad: Player
    {
        public int SquadID { get; set; }
        public int CoachID { get; set; }

    }
}
