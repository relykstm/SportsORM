using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Baseball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {

            ViewBag.WomensLeagues = context.Leagues
                .Where(l => l.Name.Contains("Women"));
            ViewBag.HockeyLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Hockey"));
            ViewBag.NonFootballLeagues = context.Leagues
                .Where(l => !l.Sport.Contains("Football"));
            ViewBag.ConferenceLeagues = context.Leagues
                .Where(l => l.Name.Contains("Conference"));
            ViewBag.AtlanticLeagues = context.Leagues
                .Where(l => l.Name.Contains("Atlantic"));
            ViewBag.DallasTeams = context.Teams
                .Where(t => t.Location.Contains("Dallas"));
            ViewBag.RaptorsTeams = context.Teams
                .Where(t => t.TeamName.Contains("Raptors"));
            ViewBag.CityTeams = context.Teams
                .Where(t => t.Location.Contains("City"));
            ViewBag.TTeams = context.Teams
                .Where(t => t.TeamName[0]=='T');
            ViewBag.AllTeamsAlphabeticallyByLocation = context.Teams
                .OrderBy(t => t.Location);
            ViewBag.AllTeamsReverseOrderByTeamName = Enumerable.Reverse(context.Teams.OrderBy(t => t.TeamName));  
            ViewBag.CooperPlayers = context.Players
                .Where(p => p.LastName.Contains("Cooper"));
            ViewBag.JoshuaPlayers = context.Players
                .Where(p => p.FirstName.Contains("Joshua"));
            ViewBag.CooperNotJoshuaPlayers = context.Players
                .Where(p => p.LastName.Contains("Cooper")&& !p.FirstName.Contains("Joshua"));
            ViewBag.AlexanderWyattPlayers = context.Players
                .Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt"))
                .OrderBy(p => p.TeamId);

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}