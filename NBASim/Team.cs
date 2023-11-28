using System;
using System.Collections;

namespace NBASim
{
	public class Team
	{
		private String name;
		private String location;
		private int elo;

		private int chipsWon;
		private int gamesWon;
		private int gamesPlayed;

        private Player[] roster;

		private int[] history;

		public Team(String? teamName, String? teamLocation, bool good)
		{
			chipsWon = 0;
			gamesWon = 0;

			this.roster = new Player[5];

			if (good)
			{
				roster = BuildGoodRoster();
			} else
			{
				roster = BuildBadRoster();
			}


			history = new int[20];

			if (teamName == null || teamLocation == null)
			{
				throw new Exception("null team name or location");
            }

			name = Convert.ToString(teamName);
			location = Convert.ToString(teamLocation);
		}

		public String GetName()
		{
			return name;
		}

		public void SetWins()
		{
			gamesWon++;
		}
		public int GetWins()
		{
			return gamesWon;
		}

		public void SetGames()
		{
			gamesPlayed++;
		}
		public int GetGames()
		{
			return gamesPlayed;
		}

		public void SetChips()
		{
			chipsWon++;
		}
		public int GetChips()
		{
			return chipsWon;
		}

		public void AddHistory(int wins, int year)
		{
			history[year] = wins;
		}
		public int GetHistory(int year)
		{
			return history[year];
		}
		public Player GetPlayer(int player)
		{
			return roster[player];
		}

		public Player[] BuildGoodRoster()
		{

            double[] s = new double[3];
			Player[] roster = new Player[5];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = .80;
            }

            for (int i = 0; i < roster.Length; i++)
            {
                roster[i] = new Player($"Player {i}", i, s);
            }

			return roster;
        }

        public Player[] BuildBadRoster()
        {

            double[] s = new double[3];
            Player[] roster = new Player[5];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = .60;
            }

            for (int i = 0; i < roster.Length; i++)
            {
                roster[i] = new Player($"Player {i}", i, s);
            }

            return roster;
        }
    }
}

