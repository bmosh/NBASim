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

            Simulation sim = new Simulation("Boston", "Celtics", true);

            while (state != 3)
			{
                switch (state)
                {
                    case <= 0:
                        Console.WriteLine("state = 0. Press any key to start");
                        Console.ReadKey();
                        Console.WriteLine();
                        state = 1;
                        break;

                    case <= 1:
                        Console.WriteLine("State = 1. Game in progress");
                        

                        while (sim.GetSeasonsPlayed() < 1)
                        {
                            sim.RunSeason();
                            Console.WriteLine($"In season '{sim.GetSeasonsPlayed()}', your '{team}' team won {sim.GetTeam().GetHistory(sim.GetSeasonsPlayed()-1)} games.");
                        }

                        Console.WriteLine("Simulation Ended. Moving to state 2");
                        state = 2;
                        break;

                    case <= 2:
                        Console.WriteLine("State = 2. Final Stats:");
                        Console.WriteLine($"Total Wins: '{sim.GetTeam().GetWins()}'");
                        Console.WriteLine($"Total Games Played: '{sim.GetTeam().GetGames()}'");
                        Console.WriteLine($"Total Championships Won: '{sim.GetTeam().GetChips()}'");
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

