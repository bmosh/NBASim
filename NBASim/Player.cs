using System;
namespace NBASim
{
	public class Player
	{
		private String name;
		private int number;

		private double[] stats;


		public Player(String name, int number, double[] stats)
		{
			this.name = name;
			this.number = number;
			this.stats = stats;
		}

		public String GetName()
		{
			return name;
		}
		public int GetNum()
		{
			return number;
		}

		public double Get2Pt()
		{
			return stats[0];
		}
		public double Get3Pt()
		{
			return stats[1];
		}
		public double GetPassing()
		{
			return stats[2];
		}

		public double TakeShot(int type)
		{
			if (type == 2)
			{
				return Get2Pt();
			}
			else 
			{
				return Get3Pt();
			}

		}

		public double MakePass()
		{
			return GetPassing();
		}
	}
}

