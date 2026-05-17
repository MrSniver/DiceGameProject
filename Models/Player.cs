namespace Models;

public class Player
{
    public Player()
    {
        PlayerScore = Enumerable.Repeat(-1, 13).ToList();
    }

    public int PlayerNumber { get; set; }
    public List<int> PlayerScore { get; set; }
}