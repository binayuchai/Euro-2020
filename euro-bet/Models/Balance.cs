using System;

namespace euro_bet.Models
{
    public class Balance
    {
        public int BalanceID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}