using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assassin.Models
{

  public class Game
  {
    public int id { get; set; }
    public string team_name { get; set; }
    public string password { get; set; }
    public int start { get; set; }
    public int end { get; set; }
    public int player_count { get; set; 

    public void BeginGame(int gameId)
    {
      var db = new AssassinContext();
      Player.AssignAssassinId();
      foreach (Player player in Player.GetAll())
      {
        Contract firstContract = new Contract {game_id = gameId, assassin_id = player.assassin_id, target_id = (player.assassin_id + 1), contract_start = DateTime.now, fullfillment = 0};
        db.contracts.Add(firstContract);
      }
      db.SaveChanges();
    }

  }
}
