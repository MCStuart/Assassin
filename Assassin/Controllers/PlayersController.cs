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

      [HttpGet("/player/sign-up")]
      public IActionResult New()
      {
        return View();
      }

      [HttpGet("/player/sign-up/authenticate")]
      public IActionResult AuthenticateGroup(string gameName, string gamePassword)
      {
        var db = new AssassinContext();
        Game thisGame = db.games.Where(g => g.team_name == gameName && g.password == gamePassword).FirstOrDefault();
        if (thisGame == null)
        {
          List<string> model = new List<string> {"The team name and/or password is incorrect", "Try again."};
          return View("New", model);
        }
        else
        {
          List<Game> GameList = new List<Game> {thisGame};
          return View("New", GameList);
        }
      }

      [HttpPost("/player/sign-up-success")]
      public IActionResult CreatePlayer(string name, string email, string password, string phoneNumber, string agentName, int gameId)
      {
        var db = new AssassinContext();
        var player = new Player {name = name, password = password, email = email, code_name = agentName, game_id = gameId, phone_number = phoneNumber};
        var foundGame = db.games.Find(gameId);
        db.players.Add(player);
        db.SaveChanges();
        return RedirectToAction("Consent", new {gameId = player.game_id, id = player.id});
      }

      [HttpGet("/game/{gameId}/player/{id}/consent")]
      public IActionResult Consent(int gameId, int id)
      {
          var db = new AssassinContext();
          Game thisGame = db.games.Find(gameId);
          Player thisPlayer = db.players.Find(id);
          Dictionary<string, object> model = new Dictionary<string, object>{{"game", thisGame}, {"player", thisPlayer}};
          return View(model);
      }

      [HttpGet("/game/{gameId}/player/{id}")]
      public IActionResult Index(int gameId, int id)
      {
          var db = new AssassinContext();
          Game thisGame = db.games.Find(gameId);
          Player thisPlayer = db.players.Find(id);
          Dictionary<string, object> model = new Dictionary<string,object>{{"game", thisGame}, {"player", thisPlayer}};
          return View(model);
      }

      [HttpPost("/game/{gameId}/player/{id}/start-game")]
      public IActionResult StartGame(int gameId, int id)
      {
          var db = new AssassinContext();
          Game thisGame = db.games.Find(gameId);
          thisGame.BeginGame();
          // Player thisPlayer = db.players.Find(id);
          // Dictionary<string, object> model = new Dictionary<string,object>{{"game", thisGame}, {"player", thisPlayer}};
          return RedirectToAction("Index");
      }

    }
}
