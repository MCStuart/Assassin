using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assassin.Models
{

  public class Player
  {
    public int id { get; set; }
    public bool alive { get; set; }
    public int assassin_id { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string code_name { get; set; }
    public int game_id { get; set; }
    public int spoon_score { get; set; }
    public int sock_score { get; set; }
    public string phone_number { get; set; }
  }
}
