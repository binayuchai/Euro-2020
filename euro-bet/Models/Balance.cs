using System;

namespace euro_bet
{
    public class Balance
    {
        public int BalanceID { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}