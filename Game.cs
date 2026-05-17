using Models;
using Utils;

public class Game
{
    public void RunGame(int playerCount, int currentPlayer)
    {
        var diceLogic = new DiceLogic();
        var scoreTableLogic = new ScoreTableLogic();
        List<Player> players = SetUpPlayers(playerCount);
        bool running = false;

        do
        {
            running = true;
            int rolls = 3;

            if (players[currentPlayer - 1].PlayerScore.All(x => x != -1))
            {
                Console.WriteLine("Tabela wyników aktualnego gracza jest już wypełniona");
                currentPlayer++;
                if(currentPlayer > playerCount)
                    currentPlayer = 1;
                continue;
            }

            Console.WriteLine($"Aktualny gracz: {currentPlayer}");

            Console.WriteLine("Rzucanie kośćmi...");

            List<int> diceResults = diceLogic.FirstDiceRolls();
            rolls -= 1;
            string rollResults = string.Join(", ", diceResults);
            Console.WriteLine("---------------");
            Console.WriteLine($"Wynik rzutu: {rollResults}");
            Console.WriteLine("---------------");

            bool playerTurnFinished = false;

            do
            {
                Console.WriteLine($"1. Przerzucic kości? Możliwa ilość przerzutów: {rolls}");
                Console.WriteLine("2. Dodaj wyniki do tabeli");
                Console.WriteLine("3. Sprawdź tabelę");
                int input = InputControlService.SingleInputValidation();
                switch (input)
                {
                    case 1:
                        if(rolls <= 0)
                        {
                            Console.WriteLine("Brak dodatkowych przerzutów. Dodaj wynik do tabelki");
                            break;
                        }
                        Console.WriteLine("Które kości przerzucić? (przykład kości: 1, 2, 3)");
                        List<int> diceInput = InputControlService.DiceInputValidation();
                        if(diceLogic.RollSelectedDices(diceResults, diceInput))
                        {
                            rollResults = string.Join(", ", diceResults);
                            Console.WriteLine("---------------");
                            Console.WriteLine($"Wynik rzutu: {rollResults}");
                            Console.WriteLine("---------------");
                            rolls -= 1;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Aktualna tabela wyników: ");
                        scoreTableLogic.DrawTable(players[currentPlayer-1].PlayerScore);
                        scoreTableLogic.addToTable(players[currentPlayer-1].PlayerScore, diceResults);
                        playerTurnFinished = true;
                        break;
                    case 3:
                        Console.WriteLine("Aktualna tabela wyników: ");
                        scoreTableLogic.DrawTable(players[currentPlayer-1].PlayerScore);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór, spróbuj ponownie!");
                        break;
                }
            }while(!playerTurnFinished);

            currentPlayer++;
            bool allPlayersDone = players.All(p => p.PlayerScore.All(x => x != -1));
            if(allPlayersDone)
            {
                Console.WriteLine("Tabele wyników wszystkich graczy są pełne");
                running = false;
            }
            else if(currentPlayer > playerCount)
                currentPlayer = 1;
        }while(running);

        Console.WriteLine("Ostateczne wyniki: ");
        scoreTableLogic.CountPlayerScores(players);


    }

    public List<Player> SetUpPlayers(int playerCount)
    {
        List<Player> players = new List<Player>();

        for(int i = 0; i < playerCount; ++i)
        {
            players.Add(new Player(){ PlayerNumber = i + 1});
        }

        return players;
    }
}