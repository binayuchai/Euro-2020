using System;

namespace euro_bet.Models
{
    [Serializable]
    public class SignupViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}