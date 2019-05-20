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
    public int player_count { get; set; }

  }
}
