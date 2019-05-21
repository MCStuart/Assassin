using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assassin.Models
{

  public class Contract
  {
    public int id { get; set; }
    public int game_id { get; set; }
    public int assassin_id { get; set; }
    public int target_id { get; set; }
    public DateTime contract_start { get; set; }
    public DateTime contract_end { get; set; }
    public int is_fulfilled { get; set; }
    public string weapon { get; set; }

    public static CloseContract(int contractId, int playerId, string weapon)
    {
      var db = new AssassinContext();
      var selectedContract = db.contracts.Find(contractId);
      selectedContract.weapon = weapon;
      selectedContract.contract_end = DateTime.Now;
      selectedContract.is_fulfilled = 1;
      var selectedPlayer = db.players.Find(playerId);
      if (weapon == "sock")
      {
        selectedPlayer.sock_score++;
      }
      else if (weapon == "spoon")
      {
          selectedPlayer.spoon_score++;
      }
      db.SaveChanges();
    }

    public static KillTarget(int contractId)
    {
      var db = new AssassinContext();
      var completedContract = db.contracts.Find(contractId);
      int newAssassin = completedContract.assassin_id;
      int newGameId = completedContract.game_id;
      Contract deadContract = db.contracts.Where( c => c.assassin_id == completedContract.target_id && c.is_fulfilled == 0);
      int newTarget = deadContract.target_id;
      if (isGameOver(newGameId, newAssassin, newTarget) != 1) {
        Contract newContract = new Contract {game_id = newGameId, assassin_id = newAssassin, target_id = newTarget, contract_start = DateTime.Now, is_fulfilled = 0};
        db.contracts.Add(newContract);
      }
      db.SaveChanges();
    }

    public int static IsGameOver(int gameId, int assassinId, int targetId)
    {
      var db = new AssassinContext();
      var selectedGame = db.games.Find(gameId);
      if (assassinId == targetId)
      {
        selectedGame.is_end = 1;
        selecteGame.is_start = 0;
      }
      db.SaveChanges();
      return selectedGame.is_end;
    }
  }
}
