using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assassin.Models;

namespace Assassin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/rules")]
        public IActionResult Rules()
        {
            return View();
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/authenticate")]
        public IActionResult Authenticate(string userName, string uPassword)
        {
            var db = new AssassinContext();
            Player thisPlayer = db.players.Where(p => p.email == userName && p.password == uPassword).FirstOrDefault();
            if (thisPlayer == null)
            {
              return RedirectToAction("TryAgain");
            }
            else
            {
              return RedirectToAction("Index", "Players", new {gameId = thisPlayer.game_id, id = thisPlayer.id});
            }
        }

        [HttpGet("/try-again")]
        public IActionResult TryAgain()
        {
            return View();
        }

        
    }
}
