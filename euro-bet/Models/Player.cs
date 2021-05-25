using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
     public class Player: Person
    {
        public int PlayerID { get; set; }
        public string ClubName { get; set; }
        public Country Country { get; set; }
    }

}
