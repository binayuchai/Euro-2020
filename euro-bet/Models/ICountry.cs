using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
    interface ICountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Flag { get; set; }
    }
}