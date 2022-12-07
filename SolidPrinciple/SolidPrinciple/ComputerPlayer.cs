namespace SolidPrinciple
{
    /// <summary>
    /// Игрок - компьютер
    /// </summary>
    public class ComputerPlayer : Player, IComputer
    {
        /// <summary>
        /// Настройки игры
        /// </summary>
        public GameSettings gameSettings { get; set; }
        
        /// <summary>
        /// Коллекция загаданных компьютером чисел/
        /// </summary>
        public List<int> playerSecrets { get; set; } = new List<int>();

        /// <summary>
        /// Число игроков
        /// </summary>
        private readonly int playerNumbers;

        public ComputerPlayer(int playerNumber)
        {
            gameSettings = new();
            this.playerNumbers = playerNumber;

            // Загадываем случайное число для каждого игрока
            for (int i = 0; i < playerNumbers; i++)
            {
                playerSecrets.Add(new Random().Next(gameSettings.MinRange, gameSettings.MaxRange + 1));
            }
        }

        /// <summary>
        /// Переопределение абстрактного метода. Демонстрация принципа 3.
        /// </summary>
        /// <returns></returns>
        public override bool NextStep()
        {
            return true;
        }

        
        public int PlayerStep(int player, int step)
        {
            if (step == playerSecrets[player])
            {
                return 0;
            }
            if (step > playerSecrets[player])
            {
                return 1;
            }
            return -1;
        }
    }
}
