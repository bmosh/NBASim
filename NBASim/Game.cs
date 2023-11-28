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

		public Game(Team t1, Team t2, int len = 48*60, bool debug=false)
		{
			team1 = t1;
			team2 = t2;

			winner = PlayGame(len, debug);

			if (debug)
			{
                if (winner == 0)
                {
                    Console.WriteLine("You win!");
                }
                else
                {
                    Console.WriteLine("You Lose, Get Fucked!");
                }
            }


		}

		public int PlayGame(int len, bool debug)
		{
            score1 = 0;
            score2 = 0;

            double timer = 0.0;

            bool pos = true;

            Random r = new Random();

            while (timer < len)
            {
                PlayPossession(r, pos);
				timer += AddPosLen(r.NextDouble());

				if (debug)
                {
                    Console.WriteLine($"Time: {timer}, Score1: {score1}, Score2: {score2}, Possession: {TeamInPossession(pos).GetName()}");
				}

				pos = !pos;
            }

            if (score2 > score1)
            {
                winner = 1;
            }
            else if (score1 > score2)
            {
                winner = 0;
            }
            else
            {
                if (r.NextDouble() >= .5)
                {
                    winner = 0;
                }
                else
                {
                    winner = 1;
                }

            }
			return winner;
        }

        public int GetWinner()
        {
            return winner;
        }

        double AddPosLen(double u)
		{
			return 12.0;
		}
		public Team TeamInPossession(bool b)
		{
			if (b)
			{
				return team1;
			} else
			{
				return team2;
			}
		}
		public int ShotType(double d)
		{
			if (d < .8)
			{
				return 2;
			} else
			{
				return 3;
			}
		}

		public void PlayPossession(Random r, bool pos)
		{
			double shotclock = 0;

			var t = TeamInPossession(pos);

			Player onBall = t.GetPlayer(0);

			while (shotclock < 24)
			{
				double decision = r.NextDouble();

				if (decision > .83)
				{
					double shot = r.NextDouble();

					int type = ShotType(shot);

					double successOdds = onBall.TakeShot(type);

					double outcome = r.NextDouble();

					if (successOdds > outcome)
					{
						if (t == team1) {
							score1 += type;
						} else
						{
							score2 += type;
						}
					}
					break;
				} else
				{
					double pass = r.NextDouble();
					double successOdds = onBall.GetPassing();

					if (successOdds > pass)
					{
						onBall = t.GetPlayer(Convert.ToInt32(Math.Floor(r.NextDouble()*5)));
					}
					else
					{
						break;
					}
				}
				shotclock += 3;
			}
			
        }
    }
	
}

