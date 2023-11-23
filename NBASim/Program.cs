
var test = new Simulation(82, "Celtics");

Console.WriteLine(test.getSeasonLength());

public class Simulation
{
    private int numGames;
    private String teamName;


    public Simulation(int seasonLen, String team)
    {
        numGames = seasonLen;
        teamName = team;
    }
    public int getSeasonLength()
    {
        return numGames;
    }
}
