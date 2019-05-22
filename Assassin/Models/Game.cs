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

    public Player LastAlive()
    {
      var db = new AssassinContext();
      Player lastAlive = db.players.Where(p => p.is_alive == 1 && p.game_id == this.id).FirstOrDefault();
      return lastAlive;
    }

    public Player FirstDead()
    {
      var db = new AssassinContext();
      Contract firstCompletedContract = db.contracts.Where(c => c.contract_end != null && c.game_id == this.id).OrderBy(c => c.contract_end).First();
      int firstTarget = firstCompletedContract.target_id;
      Player firstDead = db.players.Where(p => p.assassin_id == firstTarget && p.game_id == this.id).FirstOrDefault();
      return firstDead;
    }

    public Dictionary<string,object> MostKills()
    {
      var db = new AssassinContext();
      Player mostKills = db.players.OrderByDescending(p => p.spoon_score + p.sock_score).First();
      int total = mostKills.spoon_score + mostKills.sock_score;
      Dictionary<string, object> thisDictionary = new Dictionary<string, object> {{"player", mostKills}, {"total", total}};
      return thisDictionary;
    }

    public Player MostSpoonKills()
    {
      var db = new AssassinContext();
      Player mostSpoonKills = db.players.OrderByDescending(p => p.spoon_score).First();
      return mostSpoonKills;
    }

    public Player MostSockKills()
    {
      var db = new AssassinContext();
      Player mostSockKills = db.players.OrderByDescending(p => p.sock_score).First();
      return mostSockKills;
    }

    public List<Player> DailyStats()
    {
      var db = new AssassinContext();
      DateTime today = DateTime.Today;
      List<Contract> contractsToday = db.contracts.Where(c => c.is_fulfilled == 1 && c.contract_end.Date == today && c.game_id == this.id).ToList();
      List<Player> playerDeathsToday = new List<Player> {};
      foreach(Contract contract in contractsToday)
      {
        Player targetPlayer = db.players.Where( p => p.assassin_id == contract.target_id && p.game_id == this.id).FirstOrDefault();
        playerDeathsToday.Add(targetPlayer);
      }
      return playerDeathsToday;
    }

    // public Dictionary<string, object> GameReview()
    // {
    //   var db = new AssassinContext();
    //
    //   List<Contract> contractsToday = db.contracts.Where(c => c.is_fulfilled == 1 && c.contract_end.Date == today && c.game_id == this.id).ToList();
    //   List<Player> playerDeathsToday = new List<Player> {};
    //   foreach(Contract contract in contractsToday)
    //   {
    //     Player targetPlayer = db.players.Where( p => p.assassin_id == contract.target_id && p.game_id == this.id).FirstOrDefault();
    //     playerDeathsToday.Add(targetPlayer);
    //   }
    //   return playerDeathsToday;
    // }
  }
}
