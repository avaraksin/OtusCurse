namespace SolidPrinciple
{
    /// <summary>
    /// Интерфейс родителя всех игроков
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Ход игрока
        /// Абстрактный метод для реализации принципа L
        /// </summary>
        /// <returns></returns>
        public abstract bool NextStep();
    }
}
