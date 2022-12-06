using SolidPrinciple;

GameSettings gameSettings = GetGameSettings.Get();
int attempt = 0;
int secretNumber = new Random().Next(gameSettings.MinRange, gameSettings.MaxRange + 1);


do
{
    int NumberOfPlayers;
    string answer;

    do
    {
        Console.Write($"Укажите число игроков (1 - 5): ");
        answer = Console.ReadLine();
    }
    while (!int.TryParse(answer, out NumberOfPlayers) &&
            NumberOfPlayers < 0 &&
            NumberOfPlayers > 5);

    Game game = new();

    for (var i = 0; i < NumberOfPlayers; i++)
    {
        Console.Write($"Укажите имя {i + 1}-го игрока: ");
        string playerName = Console.ReadLine();

        game.players.Add(new HumanPlayer(playerName));
    }

    game.computer = new ComputerPlayer();


}
while (true);

do
{
    string answer;
    int tryInteger;
    
    do
    {
        Console.Write($"Укажите число от {gameSettings.MinRange} до {gameSettings.MaxRange}:");
        answer = Console.ReadLine();
    }
    while (!int.TryParse(answer, out tryInteger) && 
            tryInteger < gameSettings.MinRange &&
            tryInteger > gameSettings.MaxRange);

    if (++attempt <= gameSettings.AttempNumber)
    {
        if (tryInteger == secretNumber)
        {
            Console.WriteLine("Вы выграли!");
            Console.WriteLine($"Компьютер загадал число: {secretNumber}");
            break;
        }

        if(tryInteger < secretNumber)
        {
            Console.WriteLine("Меньше");
            continue;
        }
        Console.WriteLine("Больше");
    }
    else
    {
        Console.WriteLine("Вы израсходовали все попытки! Сожалею...");
        Console.WriteLine($"Компьютер загадал число: {secretNumber}");
        break;
    }

}
while (true);





