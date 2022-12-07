namespace SolidPrinciple
{
    /// <summary>
    /// Реализация логики игры
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Список игроков - людей
        /// </summary>
        public List<IHuman> players { get; set; }
        
        
        /// <summary>
        /// Компьютер
        /// </summary>
        public IComputer computer { get; set; }


        /// <summary>
        /// Список с номерами попыток каждого игрока
        /// </summary>
        public List<int> playerAttemp = new List<int>();


        /// <summary>
        /// Число игроков
        /// </summary>
        private readonly int playersNumber;

        public Game(int playersNumber)
        {
            players = new List<IHuman>();
            this.playersNumber = playersNumber;

            // Число начальных попыток у всех игроков - 0.
            for (var i = 0; i < playersNumber; i++)
            {
                playerAttemp.Add(0);
            }
        }

        public void Play()
        {
            bool nextStep = true; // Игра продолжается? 
            while (nextStep)
            {
                //Каждый игрок делает свой ход в порядке очереди
                for (var i = 0; i < playersNumber; i++)
                {
                    // Проверяем, что игрок не израсходовал свли попытки
                    if (++playerAttemp[i] > computer.gameSettings.AttempNumber)
                    {
                        Console.WriteLine($"Игрок {players[i].PlayerName}. Вы израсходовали все свои попытки! Компьютер загадал число {computer.playerSecrets[i]}.");
                        players[i].GameOver = true;

                        // Если все игроки израсходовали свои попытки - игра завершается
                        if (players.Count(x => x.GameOver == false) == 0)
                        {
                            nextStep = false;
                            break;
                        }

                        continue;
                    }

                    // Получаем ход игрока
                    Console.WriteLine();
                    Console.WriteLine($"Ход игрока {players[i].PlayerName}. Попытка {playerAttemp[i]}");
                    string answer;
                    int tryInteger;

                    do
                    {
                        Console.Write($"Укажите число от {computer.gameSettings.MinRange} до {computer.gameSettings.MaxRange}:");
                        answer = Console.ReadLine();
                    }
                    while (!int.TryParse(answer, out tryInteger) &&
                            tryInteger < computer.gameSettings.MinRange &&
                            tryInteger > computer.gameSettings.MaxRange);

                    // Результат хода
                    var stepResult = computer.PlayerStep(i, tryInteger);

                    // Обработка результата хода.
                    if (stepResult == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Игрок {players[i].PlayerName} выграл!");

                        // Если есть выгравший - остальным показываем загаданные числа.
                        for (var j = 0; j < playersNumber; j++)
                        {
                            if (i != j)
                            {
                                Console.WriteLine($"Для игрока {players[j].PlayerName} компьютер загадал число {computer.playerSecrets[j]}");
                            }
                        }
                        nextStep = false;
                        break;
                    }

                    if (stepResult == 1)
                    {
                        Console.WriteLine("Ваше число Больше");
                        continue;
                    }

                    Console.WriteLine("Ваше число Меньше");
                }
            }
        }
    }
}
