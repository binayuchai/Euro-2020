using System;

namespace euro_bet.Models
{
     public interface IPerson
    {
        public int PersonID();
        public string FirstName();
        public string MiddleName();
        public string LastName();
        
    }
}