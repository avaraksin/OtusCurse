namespace SolidPrinciple
{
    /// <summary>
    /// Интрфейс игрока-компьютера.
    /// </summary>
    public interface IComputer : IPlayer
    {
        /// <summary>
        /// Настройки игры
        /// </summary>
        public GameSettings gameSettings { get; set; }


        /// <summary>
        /// Список загаданных чисел
        /// </summary>
        public List<int> playerSecrets { get; set; }


        /// <summary>
        /// Ответ компьютера
        /// </summary>
        /// <param name="player"> Номер игрока</param>
        /// <param name="step">Число, которое ввел игрок</param>
        /// <returns>
        /// 0 - совпадение.
        /// 1 - введенное число больше
        /// -1 - введенное число меньше
        /// </returns>
        public int PlayerStep(int player, int step);
    }
}
