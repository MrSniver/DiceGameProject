public interface IScoreValidator
{
    bool isValid(List<int> diceResults);
    int CalculateScore(List<int> diceResults);
}

public class OnesStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.Any(x => x == 1);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Where(x => x == 1).Sum();
    }
}

public class TwosStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.Any(x => x == 2);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Where(x => x == 2).Sum();
    }
}

public class ThreesStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.Any(x => x == 3);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Where(x => x == 3).Sum();
    }
}

public class FoursStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.Any(x => x == 4);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Where(x => x == 4).Sum();
    }
}

public class FivesStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.Any(x => x == 5);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Where(x => x == 5).Sum();
    }
}

public class SixesStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.Any(x => x == 6);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Where(x => x == 6).Sum();
    }
}

public class ThreeOfAKindStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.GroupBy(x => x).Any(g => g.Count() >= 3);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Sum();
    }
}

public class FourOfAKindStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.GroupBy(x => x).Any(g => g.Count() >= 4);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Sum();
    }
}

public class FullHouseStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
        var groups = diceResults.GroupBy(x => x).ToList();
        return groups.Count == 2 && (groups[0].Count() == 3 || groups[0].Count() == 2);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return 25;
    }
}

public class SmallStraightStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
        var distinct = diceResults.Distinct().OrderBy(x => x).ToList();
    
        return (distinct.Contains(1) && distinct.Contains(2) && distinct.Contains(3) && distinct.Contains(4)) ||
                (distinct.Contains(2) && distinct.Contains(3) && distinct.Contains(4) && distinct.Contains(5)) ||
                (distinct.Contains(3) && distinct.Contains(4) && distinct.Contains(5) && distinct.Contains(6));
    }

    public int CalculateScore(List<int> diceResults)
    {
        return 30;
    }
}

public class LargeStraightStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
        var distinct = diceResults.Distinct().OrderBy(x => x).ToList();
    
        return (distinct.Contains(1) && distinct.Contains(2) && distinct.Contains(3) && distinct.Contains(4) && distinct.Contains(5)) ||
                (distinct.Contains(2) && distinct.Contains(3) && distinct.Contains(4) && distinct.Contains(5) && distinct.Contains(6));
    }

    public int CalculateScore(List<int> diceResults)
    {
        return 40;
    }
}

public class KingStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return diceResults.GroupBy(x => x).Any(g => g.Count() >= 5);
    }

    public int CalculateScore(List<int> diceResults)
    {
        return 50;
    }
}

public class ChanceStrategy: IScoreValidator
{
    public bool isValid(List<int> diceResults)
    {
       return true;
    }

    public int CalculateScore(List<int> diceResults)
    {
        return diceResults.Sum();
    }
}