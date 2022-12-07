namespace SolidPrinciple
{
    /// <summary>
    /// Интерфейс игрока - человека. Демонстрация принципов 4 и 5.
    /// </summary>
    public interface IHuman : IPlayer
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string PlayerName { get; set; }


        /// <summary>
        /// Флаг - игрок израсходовал все свои попытки
        /// </summary>
        public bool GameOver { get; set; }
    }
}
