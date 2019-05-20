using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assassin.Models
{

  public class Player
  {
    public int id { get; set; }
    public bool alive { get; set; }
    public int assassin_id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string code_name { get; set; }
    public int game_id { get; set; }
    public int spoon_score { get; set; }
    public int sock_score { get; set; }
    public string phone_number { get; set; }

    // public List<string> obit_mad_lib {}

    public static List<Player> GetAll()
    {
      return new AssassinContext().players.ToList();
    }

    public void AssignAssassinId()
    {
      int playerCount = Player.GetAll().Count;
      Random random = new Random();
      var db = new AssassinContext();
      foreach(Player player in Player.GetAll())
      {
        while (player.assassin_id = null)
        {
          int randomNumber = random.Next(1, playerCount + 1);
          int count = 0;
          foreach(Player checkPlayer in Player.GetAll())
          {
            if(randomNumber == checkPlayer.assassin_id)
            {
              count++;
            }
          }
          if(count == 0)
          {
            player.assassin_id = randomNumber;
          }
        }
      }
      db.SaveChanges();
    }

  }
}
