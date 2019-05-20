using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assassin.Models
{

  public class AssassinContext : DbContext
  {
    public DbSet<Game> games { get; set; }
    public DbSet<Player> players { get; set; }
    public DbSet<Contract> contracts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=assassins;user=root;password=root;port=8889;");
    }
  }
}
