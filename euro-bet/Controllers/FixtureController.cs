using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using euro_bet.Models;
using euro_bet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace euro_bet.Controllers
{
    public class FixtureController : Controller
    {
        private readonly ILogger<FixtureController> _logger;
        private readonly EuroBetContext _dbContext;

        public FixtureController(ILogger<FixtureController> logger, EuroBetContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            FixtureViewModel model = new FixtureViewModel();
            model.Fixtures = _dbContext.Fixture
            .Include(x=> x.SquadHome)
            .Include(x=> x.SquadAway)
            .Include(x=> x.SquadHome.Country)
            .Include(x=> x.SquadAway.Country)
            .OrderBy(x=> x.Date)
            .ToList();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult New()
        {
            FixtureViewModel model = new FixtureViewModel();
            model.HomeSquads = _dbContext.Squad
                                .Include(s => s.Country)
                                .Select(x=> new SelectListItem(){ Text = x.Country.CountryName, Value = x.SquadID.ToString()});
            model.AwaySquads = _dbContext.Squad
                                .Include(s => s.Country)
                                .Select(x=> new SelectListItem(){ Text = x.Country.CountryName, Value = x.SquadID.ToString()});
            return View(model);
        }

        [HttpPost]
        public IActionResult New(FixtureViewModel model)
        {
            Fixture fixture = new Fixture();
            fixture.SquadHome = _dbContext.Squad.FirstOrDefault(x=> x.SquadID == model.HomeSquadID);
            fixture.SquadAway = _dbContext.Squad.FirstOrDefault(x=> x.SquadID == model.AwaySquadID);
            fixture.Caption = model.Caption;
            fixture.Venue = model.Venue;
            fixture.Date = model.Date;
            _dbContext.Fixture.Add(fixture);
            _dbContext.SaveChanges();
            ViewBag.Message = "Success";

             model.HomeSquads = _dbContext.Squad
                                .Include(s => s.Country)
                                .Select(x=> new SelectListItem(){ Text = x.Country.CountryName, Value = x.SquadID.ToString()});
            model.AwaySquads = _dbContext.Squad
                                .Include(s => s.Country)
                                .Select(x=> new SelectListItem(){ Text = x.Country.CountryName, Value = x.SquadID.ToString()});
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
