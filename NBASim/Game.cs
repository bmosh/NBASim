using System;
namespace NBASim
{
	public class Game
	{
		private Team team1;
		private Team team2;

		private int score1;
		private int score2;

		private int winner;

		public Game(Team t1, Team t2, int len = 48*60)
		{
			team1 = t1;
			team2 = t2;

			score1 = 0;
			score2 = 0;

			double timer = 0.0;

			int pos = 0;

			Random r = new Random();

			while (timer < len)
			{
				double pos_len = r.NextDouble();
				double pos_out = r.NextDouble();

				if (pos_out >= .5)
				{
					double t = r.NextDouble();

					if (t >= .8)
					{
						if (pos == 0)
						{
							score1 += 3;
							pos = 1;
						}
						else
						{
							score2 += 3;
							pos = 0;
						}
					} else
					{
                        if (pos == 0)
                        {
                            score1 += 2;
							pos = 1;
                        }
                        else
                        {
                            score2 += 2;
							pos = 0;
                        }
                    }
				}
				timer += 12.0;
			}

			if (score2 > score1)
			{
				winner = 1;
			} else if (score1 > score2)
			{
				winner = 0;
			} else
			{
				if (r.NextDouble() >= .5)
				{
					winner = 0;
				} else
				{
					winner = 1;
				}

			}

		}

        public int GetWinner()
        {
            return winner;
        }

        double PosLen(double u)
		{
			return 0.0;
		}
    }
	
}

