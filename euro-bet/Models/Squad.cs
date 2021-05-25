using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
    public class Squad
    {
        public int SquadID { get; set; }
        public Coach Coach { get; set; }
        public Country Country { get; set; }
        List<Player> Players { get; set; }

    }
}
