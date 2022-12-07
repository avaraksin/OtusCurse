using SolidPrinciple;
string answer;
do
{
    // Получам число игроков
    int NumberOfPlayers;
    do
    {
        Console.Write($"Укажите число игроков (1 - 5): ");
        answer = Console.ReadLine();
    }
    while (!int.TryParse(answer, out NumberOfPlayers) ||
            NumberOfPlayers <= 0 || NumberOfPlayers > 5);

    Game game = new(NumberOfPlayers);

    // Получаем имена игроков
    for (var i = 0; i < NumberOfPlayers; i++)
    {
        Console.Write($"Укажите имя {i + 1}-го игрока: ");
        string playerName = Console.ReadLine();

        game.players.Add(new HumanPlayer(playerName));
    }

    game.computer = new ComputerPlayer(NumberOfPlayers);

    // играем
    game.Play();

    Console.WriteLine();
    Console.Write("Играем еще(y/n): ");
    answer = Console.ReadLine();

}
while (answer.ToLower() == "y");

