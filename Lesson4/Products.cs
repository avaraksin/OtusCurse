namespace Lesson4
{
    /// <summary>
    /// Образ таблицы Products (Продукты) в БД
    /// </summary>
    public class Products
    {
        /// <summary>
        /// Порядковый номер продукта - ключ
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// Имя продукта
        /// </summary>
        public string productName { get; set; } = string.Empty;


        /// <summary>
        /// Конструтор по умолчанию
        /// </summary>
        public Products(int id, string productName)
        {
            this.id = id;
            this.productName = productName;
        }
    }
}
