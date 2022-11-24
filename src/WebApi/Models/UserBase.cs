namespace WebApi.Models
{
    /// <summary>
    /// Родитель для всех классов - образов таблиц в БД
    /// Определяет ключ таблицы
    /// </summary>
    public abstract class UserBase
    {
        public int id { get; set; }
    }
}
