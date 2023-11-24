using System;

namespace NBASim
{
	class State
	{
		public static void Main()
		{
			int state = 0;

			while (state != 2)
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
                        Console.WriteLine("How many games would you like to play?");
                        String? input = Console.ReadLine();
                        Console.WriteLine($"Starting Simulation with '{input}' games.");

                        Simulation sim = new Simulation(82, "Celtics");

                        Console.WriteLine(sim.getSeasonLength());

                        Console.WriteLine("Simulation Ended. Moving to state 2");
                        break;

                    case <= 2:
                        Console.WriteLine("State = 2. End.");
                        state = 2;
                        break;

                    default:
                        Console.WriteLine("Undefined State. Returning to Start");
                        break;
                }
            }
		}
	}
}

