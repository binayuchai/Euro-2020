namespace euro_bet
{
    public class User: Person
    {
        public int UserID { get; set; }
        public Contact Contact { get; set; }
        public Balance Balance { get; set; }

    }
}