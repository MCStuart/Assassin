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
            var player = new Player {is_alive = 1, name = name, password = password, email = email, code_name = agentName, game_id = gameId, spoon_score = 0, sock_score = 0, phone_number = phoneNumber, is_admin = 0};
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
            List<Player> deathList = thisGame.DailyStats();
            Player thisPlayer = db.players.Find(id);
            Contract thisContract = db.contracts.Where(c => c.assassin_id == thisPlayer.assassin_id && c.is_fulfilled == 0 && thisPlayer.is_alive == 1 && c.game_id == thisGame.id).LastOrDefault();
            Dictionary<string, object> model = new Dictionary<string,object>{{"game", thisGame}, {"player", thisPlayer}, {"contract", thisContract}, {"deathList", deathList}};
            return View(model);
        }

        [HttpPost("/game/{gameId}/player/{id}/start-game")]
        public IActionResult StartGame(int gameId, int id)
        {
            var db = new AssassinContext();
            Game thisGame = db.games.Find(gameId);
            Player.AssignAssassinId(gameId);
            thisGame.BeginGame();
            Player thisPlayer = db.players.Find(id);
            return RedirectToAction("Index", new {gameId = thisGame.id, id = thisPlayer.id});
        }

        [HttpPost("/game/{gameId}/player/{id}/contract-complete")]
        public IActionResult CompleteContract(int gameId, int id, string weapon)
        {
            var db = new AssassinContext();
            Game thisGame = db.games.Find(gameId);
            Player thisPlayer = db.players.Find(id);
            Contract thisContract = db.contracts.Where(c => c.assassin_id == thisPlayer.assassin_id && c.is_fulfilled == 0 && thisPlayer.is_alive == 1).FirstOrDefault();
            thisContract.CloseContract(thisContract.id, thisPlayer.id, weapon);
            thisContract.KillTarget(thisContract.id);
            return RedirectToAction("Index", new {gameId = thisGame.id, id = thisPlayer.id});
        }

    }
}
