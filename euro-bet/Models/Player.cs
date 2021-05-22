using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
     public class Player: ICountry, IPerson
    {
        
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Flag { get; set; }
        public int PlayerID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ClubName { get; set; }

    }

}
