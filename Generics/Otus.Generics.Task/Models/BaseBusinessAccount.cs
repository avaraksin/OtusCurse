namespace Otus.Generics.Task.Models
{
    /// <summary>
    /// Инрфейс бизнес-аккаунта
    /// </summary>
    public interface IBaseBusinessAccount
    {
        /// <summary>
        /// Возвращает форматированное название объекта
        /// </summary>
        /// <returns></returns>
        string GetPrintName();

        /// <summary>
        /// Обновляет Бизнес аккаунт из пользовательского
        /// </summary>
        /// <param name="ua"></param>
        void UpdateFromUserAccount(UserAccount ua);
    }
}