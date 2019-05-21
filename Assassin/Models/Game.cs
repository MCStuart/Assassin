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
      List<Player> playerList = Player.GetAll(thisGame.id);
      foreach (Player player in playerList)
      {
        Contract firstContract = new Contract {game_id = thisGame.id, assassin_id = player.assassin_id, target_id = (player.assassin_id + 1), contract_start = DateTime.Now, is_fulfilled = 0};
        if (firstContract.target_id > playerList.Count)
        {
          firstContract.target_id = 1;
        }
        db.contracts.Add(firstContract);
      }
      db.SaveChanges();
    }

    // End of Game Statistic Methods
    public void FirstDead(int gameId)
    {
      var db = new AssassinContext();
      if (db.games.id = gameId && db.games.is_end = 1)
      {
        var firstCompletedContract = db.contracts.Where(c => contract_end.HasValue).Min(c => c.contract_end);
        var firstTarget = firstCompletedContract.target_id;
        var firstDead = db.players.name.Where(assassin_id == firstTarget);
        return firstDead;
      }
    }

    
  }
}
