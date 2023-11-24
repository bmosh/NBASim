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

		private int[] history;

		public Team(String? teamName, String? teamLocation)
		{
			chipsWon = 0;
			gamesWon = 0;

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
	}
}

