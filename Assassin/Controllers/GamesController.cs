using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assassin.Models;

namespace Assassin.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet("/game/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("/game/new")]
        public IActionResult Create(string gameName, string gamePassword, string name, string email, string password, string phoneNumber, string agentName)
        {
          var db = new AssassinContext();
          var game = new Game {team_name = gameName, password = gamePassword, start = 0, end = 0, player_count = 1};
          db.games.Add(game);
          db.SaveChanges();
          var player = new Player {name = name, password = password, email = email, code_name = agentName, game_id = game.id, phone_number = phoneNumber};
          db.players.Add(player);
          db.SaveChanges();
          return RedirectToAction("Consent", "Players", new {id = player.id});
        }

    }
}
