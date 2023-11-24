using System;

namespace NBASim
{
	class State
	{
		public static void Main()
		{
			int state = 0;

            Console.WriteLine("How many games would you like to play?");
            String? games = Console.ReadLine();
            Console.WriteLine($"Starting Simulation with '{games}' games.");

            Console.WriteLine("What team do you choose?");
            String? team = Console.ReadLine();

            Simulation sim = new Simulation(82, "Celtics");

            while (state != 3)
			{
                switch (state)
                {
                    case <= 0:
                        Console.WriteLine("state = 0. Press any key to start");
                        Console.ReadKey();
                        state = 1;
                        break;

                    case <= 1:
                        Console.WriteLine("State = 1. Game in progress");
                        

                        while (sim.GetSeasonsPlayed() < 20)
                        {
                            Console.WriteLine($"In season '{sim.GetSeasonsPlayed() + 1}', your '{team}' team won '{sim.RunSeason()}' games.");
                        }

                        Console.WriteLine("Simulation Ended. Moving to state 2");
                        state = 2;
                        break;

                    case <= 2:
                        Console.WriteLine("State = 2. Final Stats:");
                        Console.WriteLine($"Total Wins: '{sim.GetTotalWins()}'");
                        Console.WriteLine($"Total Games Played: '{sim.GetTotalGames()}'");
                        Console.WriteLine($"Total Championships Won: '{sim.GetChipsWon()}'");
                        state = 3;
                        break;

                    default:
                        Console.WriteLine("Undefined State. Returning to Start");
                        break;
                }
            }
		}
	}
}

