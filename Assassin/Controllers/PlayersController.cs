using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assassin.Models;

namespace Assassin.Controllers
{
    public class PlayersController : Controller
    {

      [HttpGet("player/sign-up")]
      public IActionResult New()
      {
          return View();
      }

      [HttpPost("/game/{gameId}/player/sign-up")]
      public IActionResult CreatePlayer(string gameName, string gamePassword, string name, string email, string password, string phoneNumber, string agentName)
      {
        var db = new AssassinContext();
           Game thisGame = db.games.Where(g => g.team_name == gameName && g.password == gamePassword).FirstOrDefault();
           var player = new Player {name = name, password = password, email = email, code_name = agentName, game_id = thisGame.id, phone_number = phoneNumber};
           db.players.Add(player);
           db.SaveChanges();
          return RedirectToAction("Consent", new {gameId = thisGame.id, id = player.id});
      }

      [HttpGet("/game/{gameId}/player/{id}/consent")]
      public IActionResult Consent()
      {
          return View();
      }

      [HttpGet("/game/{gameId}/player/{id}")]
      public IActionResult Index()
      {
          return View();
      }

    }
}
