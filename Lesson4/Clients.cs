namespace Lesson4
{
    /// <summary>
    /// Образ таблицы Clients (Клиенты) в БД
    /// </summary>
    public class Clients
    {
        /// <summary>
        /// Порядковый номер клиента - ключ
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// Имя клиента
        /// </summary>
        public string firstName { get; set; }


        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="id">Номер клиента</param>
        /// <param name="firstName">Имя клиента</param>
        public Clients(int id, string firstName)
        {
            this.id = id;
            this.firstName = firstName;
        }
    }
}
