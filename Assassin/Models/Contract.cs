using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assassin.Models
{

  public class Contract
  {
    public int id { get; set; }
    public int game_id { get; set; }
    public int assassin_id { get; set; }
    public int target_id { get; set; }
    public DateTime timestamp { get; set; }
    public bool fulfillment { get; set; }
    public string weapon { get; set; }

  }
}
