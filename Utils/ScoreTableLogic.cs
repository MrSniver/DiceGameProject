using Models;

namespace Utils;

public class ScoreTableLogic
{
    private readonly Dictionary<int, IScoreValidator> _strategies;

    public ScoreTableLogic()
    {
        _strategies = new Dictionary<int, IScoreValidator>
        {
            { 1, new OnesStrategy() },
            { 2, new TwosStrategy() },
            { 3, new ThreesStrategy() },
            { 4, new FoursStrategy() },
            { 5, new FivesStrategy() },
            { 6, new SixesStrategy() },
            { 7, new ThreeOfAKindStrategy() },
            { 8, new FourOfAKindStrategy() },
            { 9, new FullHouseStrategy() },
            { 10, new SmallStraightStrategy() },
            { 11, new LargeStraightStrategy() },
            { 12, new KingStrategy() },
            { 13, new ChanceStrategy() }
        };
    }


    public List<int> addToTable(List<int> playerScores, List<int> diceResults)
    {
        bool finishedInput = false;
        do
        {
            Console.WriteLine("Wybierz pole, do którego dodać wynik z rzutów");
            int input = InputControlService.SingleInputValidation();
        
            if (input < 1 || input > 13)
            {
                Console.WriteLine("Niepoprawny wybór, spróbuje ponownie!");
                continue;
            }

            if(playerScores[input - 1] != -1)
            {
                Console.WriteLine("To pole zostało już wypełnione!");
                continue;
            }
        
            int score = IsValidScore(input, diceResults) ? GetScore(input, diceResults) : 0;
            playerScores[input - 1] = score;
            finishedInput = true;
        }while(!finishedInput);

        return playerScores;
    }

    public bool IsValidScore(int category, List<int> diceResults)
    {
        return _strategies[category].isValid(diceResults);
    }

    public int GetScore(int category, List<int> diceResults)
    {
        return _strategies[category].CalculateScore(diceResults);
    }

    public void DrawTable(List<int> playerScores)
{
    for(int i = 0; i < playerScores.Count; i++)
    {
        string score = playerScores[i] == -1 ? "-" : playerScores[i].ToString();
        
        string categoryName = i switch
        {
            0 => "Jedynki",
            1 => "Dwójki",
            2 => "Trójki",
            3 => "Czwórki",
            4 => "Piątki",
            5 => "Szóstki",
            6 => "3 jednakowe",
            7 => "4 jednakowe",
            8 => "Full",
            9 => "Mały strit",
            10 => "Duży strit",
            11 => "Król",
            12 => "Szansa",
            _ => ""
        };
        
        Console.WriteLine($"{i+1}. {categoryName}: {score}");
    }
}

    public void CountPlayerScores(List<Player> players)
    {
        int maxScore = 0;
        Player winner = null;

        foreach(Player player in players)
        {
            int upperTableScore = player.PlayerScore.Take(6).Sum();
            int totalScore = player.PlayerScore.Sum();
            if(upperTableScore >= 63)
            {
                totalScore += 35;
                Console.WriteLine($"Gracz {player.PlayerNumber}: {totalScore} punktów z dodatkowym 35 punktów za otrzymanie 63 punktów w górnej części tabeli odpowiadającej oczkom na kościach");
            }
            else
            {
                Console.WriteLine($"Gracz {player.PlayerNumber}: {totalScore} punktów");
            }

            if(totalScore > maxScore)
            {
                maxScore = totalScore;
                winner = player;
            }
        }

        Console.WriteLine("-----------");
        Console.WriteLine($"Zwycieża gracz: {winner.PlayerNumber} z wynikiem: {maxScore}");
        Console.WriteLine("-----------");
    }
}