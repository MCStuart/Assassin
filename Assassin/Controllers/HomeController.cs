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

        // [HttpGet("/authenticate")]
        // public IActionResult Authenticate(string userName, string password)
        // {
        //     var db = new AssassinContext();
        //     Player thisPlayer = db.players.Where(p => p.email == userName && p.password == password).FirstOrDefault();
        //     if (thisPlayer)
        //     {
        //       return RedirectToAction("Index", "Players", new {id = thisPlayer.id});
        //     }
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
