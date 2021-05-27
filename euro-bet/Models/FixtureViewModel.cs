using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace euro_bet.Models
{
    public class FixtureViewModel
    {
        public string Caption { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public int HomeSquadID { get; set; }
        public int AwaySquadID { get; set; }
        public IEnumerable<SelectListItem> HomeSquads { get; set; }
        public IEnumerable<SelectListItem> AwaySquads { get; set; }

        public IEnumerable<Fixture> Fixtures { get; set; }
    }
}