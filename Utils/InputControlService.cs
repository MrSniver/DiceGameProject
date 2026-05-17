using System.Text.RegularExpressions;

namespace Utils;

class InputControlService
{
    public static int SingleInputValidation()
    {
        bool isValid = false;
        int result = 0;

        while (!isValid)
        {
            string? input = Console.ReadLine();

            if(Regex.IsMatch(input ?? "", @"^\d+$"))
            {
                result = int.Parse(input!);
                isValid = true;
            }
            else
            {
                Console.WriteLine("Niepoprawna liczba, spróbuj ponownie!");
            }
        }

        return result;
    }

    public static List<int> DiceInputValidation()
    {
        bool isValid = false;
        List<int> results = new List<int>();

        while (!isValid)
        {
            string? input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input ?? "", @"\d");

            if(matches.Count < 1 || matches.Count > 5)
            {
                Console.WriteLine("Niepoprawne liczby, spróbuj ponownie!");
                continue;
            }

            results = matches.Cast<Match>().Select(x => int.Parse(x.Value)).ToList();
            isValid = true;
        }

        return results;
    }
}