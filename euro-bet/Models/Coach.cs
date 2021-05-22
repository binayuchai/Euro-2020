using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
    public class Coach: IPerson
    {
        public int CoachID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
