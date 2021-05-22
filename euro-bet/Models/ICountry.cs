using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace euro_bet.Models
{
    public interface ICountry
    {
        public int CountryID();
        public string CountryName();
        public string Flag();

    }
}
