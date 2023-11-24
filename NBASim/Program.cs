using System;

namespace NBASim
{
    public class Simulation
    {
        private Team team;

        private int seasonsPlayed;
        private int totalWins;
        private int totalGames;
        private int chipsWon;



        public Simulation(String teamLoc, String teamName)
        {
            seasonsPlayed = 0;
            totalGames = 0;
            totalWins = 0;
            chipsWon = 0;

            team = new Team(teamName, teamLoc);

            teamName = team.GetName();

        }
        public int GetSeasonsPlayed()
        {
            return seasonsPlayed;
        }
        public int GetTotalWins()
        {
            return totalWins;
        }
        public int GetTotalGames()
        {
            return totalGames;
        }
        public int GetChipsWon()
        {
            return chipsWon;
        }
        public Team GetTeam()
        {
            return team;
        }

        public void RunSeason()
        {
            seasonsPlayed++;
            int g = 0;
            int acc = 0;

            while (g < 82)
            {
                Game gme = new Game(team, new Team("testname", "testloc"));

                if (gme.GetWinner() == 0)
                {
                    acc++;
                    team.SetWins();
                }
                g++;
                team.SetGames();
            }

            if (acc >= 48)
            {
                team.SetChips();
            }

            team.AddHistory(acc, seasonsPlayed-1);
        }
    }
}
