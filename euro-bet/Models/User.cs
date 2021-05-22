using System;
namespace euro_bet.Models
{
    public class User: IPerson
    {
        
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int UserID { get; set; }
        public Contact Contact { get; set; }
        public Balance Balance { get; set; }
    }
}