using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assassin.Models
{

  public class Player
  {
    public int id { get; set; }
    public int is_alive { get; set; }
    public int assassin_id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string code_name { get; set; }
    public int game_id { get; set; }
    public int spoon_score { get; set; }
    public int sock_score { get; set; }
    public string phone_number { get; set; }
    public string image_url { get; set; }
    public int is_admin { get; set; }

    public static List<Player> GetAll(int gameId)
    {
      var db = new AssassinContext();
      List<Player> playerList = db.players.Where(p => p.game_id == gameId).ToList();
      return playerList;
    }

    public static void AssignAssassinId(int gameId)
    {
      Random random = new Random();
      var db = new AssassinContext();
      List<Player> playerList = db.players.Where(p => p.game_id == gameId).ToList();
      int playerCount = playerList.Count;
      foreach(Player player in playerList)
      {
        while (player.assassin_id == 0)
        {
          int randomNumber = random.Next(1, playerCount+1);
          int count = 0;
          foreach(Player checkPlayer in playerList)
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
