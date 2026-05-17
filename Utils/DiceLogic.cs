namespace Utils;

public class DiceLogic
{
    public List<int> FirstDiceRolls()
    {
        List<int> diceResults = new List<int>();
        Random rnd = new Random();

        for( int i = 0; i < 5; ++i)
        {
            int roll = DiceRoll(rnd);
            diceResults.Add(roll);
        }

        return diceResults;
    }

    public bool RollSelectedDices(List<int> diceResults, List<int> diceIndexes)
    {
        Random rnd = new Random();

        foreach(int dice in diceIndexes)
        {
            int index = dice - 1;
            if(index < 0 || index >= diceResults.Count)
            {
                Console.WriteLine($"Niepoprawny numer kości: {dice}");
                return false;
            }
        }

        foreach(int dice in diceIndexes)
        {
            int index = dice - 1;
            int roll = DiceRoll(rnd);
            diceResults[index] = roll;
        }

        return true;
    }

    public int DiceRoll(Random random)
    {
        int rollResult = random.Next(1, 7);

        return rollResult;
    }
}