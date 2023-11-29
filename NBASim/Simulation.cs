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



        public Simulation(String teamLoc, String teamName, bool good)
        {
            seasonsPlayed = 0;
            totalGames = 0;
            totalWins = 0;
            chipsWon = 0;

            team = new Team(teamName, teamLoc, good);

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
                Game gme = new Game(team, team.NextGame(), debug: false);

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
        public bool RunPlayoffs()
        {
            int round = 0;


            while (round <= 3)
            {
                Console.WriteLine($"Round: {round}");
                int ourWins = 0;
                int oppWins = 0;

                while (ourWins < 4 && oppWins < 4)
                {
                    Game g = new Game(team, team.NextGame(playoffs: true), debug: true);
                    if (g.GetWinner() == 0)
                    {
                        ourWins++;
                    }
                    else
                    {
                        oppWins++;
                    }
                }

                if (ourWins > oppWins)
                {
                    round++;
                }
                else
                {
                    break;
                }
            }
            if (round == 4)
            {
                team.SetChips();
                return true;
            } else
            {
                return false;
            }
        }

        public void RunSingleGame()
        {
            Game gme = new Game(team, team.NextGame(), debug: true);
        }
    }
}
