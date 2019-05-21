using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assassin.Models
{

  public class Game
  {
    public int id { get; set; }
    public string team_name { get; set; }
    public string password { get; set; }
    public int is_start { get; set; }
    public int is_end { get; set; }

    public void BeginGame()
    {
      var db = new AssassinContext();
      Game thisGame = db.games.Find(this.id);
      thisGame.is_start = 1;
      Player.AssignAssassinId(thisGame.id);
      foreach (Player player in Player.GetAll(thisGame.id))
      {
        Contract firstContract = new Contract {game_id = thisGame.id, assassin_id = player.assassin_id, target_id = (player.assassin_id + 1), contract_start = DateTime.Now, is_fulfilled = 0};
        db.contracts.Add(firstContract);
      }
      db.SaveChanges();
    }

  }
}
