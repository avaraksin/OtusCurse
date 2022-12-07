namespace SolidPrinciple
{
    /// <summary>
    /// Родитель всех игроков
    /// </summary>
    public abstract class Player : IPlayer
    {
        /// <summary>
        /// Пустой абстрактный метод.
        /// Демонстрирует принцип 3.
        /// Каждый потомок должен иметь свою реализацию.
        /// </summary>
        /// <returns></returns>
        public abstract bool NextStep();
    }
}
