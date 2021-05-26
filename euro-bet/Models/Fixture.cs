using System;

namespace euro_bet.Models
{
    public class Fixture
    {
        public int FixtureID { get; set; }
        public string Caption { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public Squad SquadHome { get; set; }
        public Squad SquadAway { get; set; }

        public int Score_HalfTime_Home { get; set; }
        public int Score_HalfTime_Away { get; set; }
        public int Score_FullTime_Home { get; set; }
        public int Score_FullTime_Away { get; set; }

        public Squad GetWinner()
        {
            if(Score_FullTime_Home> Score_FullTime_Away)
            {
                return this.SquadHome;
            }
            else if(Score_FullTime_Home < Score_FullTime_Away)
            {
                return this.SquadAway;
            }
            else
            {
                //no winner
                return null;
            }
        }

    }
}