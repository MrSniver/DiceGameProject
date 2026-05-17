using Utils;

class Program
{
    static void Main(string[] args)
    {
        bool running = false;
        do
        {
            Console.WriteLine("1. Wystartuj grę\b");
            Console.WriteLine("2. Zamknij grę\b");
            running = true;
            int input = InputControlService.SingleInputValidation();
            switch (input)
            {
                case 1:
                    Console.WriteLine("Ilu graczy?\b"); 
                    int playerCount = InputControlService.SingleInputValidation(); 
                    if(playerCount < 2 || playerCount > 4)
                    {
                        Console.WriteLine("Gra musi mieć od 2 do 4 graczy");
                        continue;
                    }
                    new Game().RunGame(playerCount, 1);
                    break;
                case 2:
                    Console.WriteLine("Zamykam grę"); 
                    running = false; 
                    break;
                default:
                    Console.WriteLine("Wprowadzono niepoprawną liczbę, spróbuj ponownie!"); break;
            }
        }while(running);
    }
}