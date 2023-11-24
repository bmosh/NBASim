public class Simulation
{
    private int numGames;
    private String teamName;

    private int seasonsPlayed;
    private int totalWins;
    private int totalGames;
    private int chipsWon;



    public Simulation(int seasonLen, String team)
    {
        seasonsPlayed = 0;
        totalGames = 0;
        totalWins = 0;
        chipsWon = 0;

        numGames = seasonLen;
        teamName = team;

    }
    public int GetSeasonLength()
    {
        return numGames;
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


    public int RunSeason()
    {
        seasonsPlayed++;
        int g = 0;
        int acc = 0;

        Random r = new Random();

        while (g < numGames)
        {
            var i = r.NextDouble();
            if (i <= .5)
            {
                acc++;
                totalWins++;
            }
            g++;
        }

        totalGames += g;
        if (acc >= 48)
        {
            chipsWon++;
        }

        return acc;
    }
}
