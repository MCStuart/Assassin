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
            DateTime nullDateTime = new DateTime(1,1,1,0,0,0);
            List<Player> playerList = Player.GetAll(thisGame.id);
            foreach (Player player in playerList)
            {
                Contract firstContract = new Contract {game_id = thisGame.id, assassin_id = player.assassin_id, target_id = (player.assassin_id + 1), contract_start = DateTime.Today, contract_end = nullDateTime, is_fulfilled = 0};
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
            DateTime comparison = new DateTime(1, 1, 1, 0, 0, 0);
            Contract firstCompletedContract = db.contracts.Where(c => c.contract_end != comparison && c.game_id == this.id).OrderBy(c => c.contract_end).First();
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

//THE CODE BELOW IS FOR END-OF-GAME STATS AND DOES NOT WORK
   /* public void AssignDeathDay()
    {
      Console.WriteLine("!!!!!!!!!| TEEEEEESSSSSSSTTTTTTT");
      var db = new AssassinContext();
      long ticksPerDay = 864000000000;
      Contract firstContract = db.contracts.Where(c => c.game_id == this.id).First();
      DateTime gameStart = firstContract.contract_start;
      Contract lastContract = db.contracts.Where(c => c.game_id == this.id && c.is_fulfilled == 1) .Last();
      DateTime gameEnd = lastContract.contract_end;
      long gameEndTicks = gameEnd.Ticks;
      Console.WriteLine("!!!!!!!!!| gameEndTicks: " + gameEndTicks.ToString());
      long gameStartTicks = gameStart.Ticks;
      long gameSpanTicks = (gameEndTicks - gameStartTicks);
      DateTime currentDate = new DateTime(gameStartTicks);
      int deathDay = 1;
      for (long i = gameStartTicks; i < gameEndTicks; i+= ticksPerDay)
      {
        List<Contract> contractList = db.contracts.Where(c => c.contract_end == currentDate).ToList();
        foreach (Contract contract in contractList)

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
        }*/

//THE CODE BELOW IS FOR END-OF-GAME STATS AND DOES NOT WORK
        /*public void AssignDeathDay()
        {
            var db = new AssassinContext();
            long ticksPerDay = 864000000000;
            Contract firstContract = db.contracts.Where(c => c.game_id == this.id).First();
            DateTime gameStart = firstContract.contract_start;
            Contract lastContract = db.contracts.Where(c => c.game_id == this.id && c.is_fulfilled == 1) .Last();
            DateTime gameEnd = lastContract.contract_end;
            long gameEndTicks = gameEnd.Ticks;
            long gameStartTicks = gameStart.Ticks;
            long gameSpanTicks = (gameEndTicks - gameStartTicks);
            DateTime currentDate = new DateTime(gameStartTicks);
            int deathDay = 1;
            for (long i = gameStartTicks; i < gameEndTicks; i+= ticksPerDay)
            {
                List<Contract> contractList = db.contracts.Where(c => c.contract_end == currentDate).ToList();
                foreach (Contract contract in contractList)
                {
                contract.death_day = deathDay;
                }
                long currentDateTicks = currentDate.Ticks;
                currentDateTicks += ticksPerDay;
                currentDate = new DateTime(currentDateTicks);
                deathDay++;
            }
        }*/
    }
}
