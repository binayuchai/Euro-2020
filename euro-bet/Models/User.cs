namespace euro_bet.Models
{
    public class User: Person
    {
        public int UserID { get; set; }
        public Account Account { get; set; }
        public Contact Contact { get; set; }
        public Balance Balance { get; set; }

    }
}