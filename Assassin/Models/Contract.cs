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
    public int fulfillment { get; set; }
    public string weapon { get; set; }


  }
}
