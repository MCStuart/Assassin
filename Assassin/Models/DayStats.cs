using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assassin.Models
{

  public class DayStats
  {
    public int id { get; set; }
    public int contract_id { get; set; }
    public int assassin_id { get; set; }
    public int target_id { get; set; }
    public DateTime date { get; set; }

  }
}
