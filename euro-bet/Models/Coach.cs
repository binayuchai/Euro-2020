using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
    public class Coach: Person
    {
        public int CoachID { get; set; }
        public Country Country { get; set; }

    }
}
