namespace Lesson4
{
    /// <summary>
    /// Образ таблицы Orders (Заказы) в БД
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// Номер заказа. Входит в составной ключ
        /// </summary>
        public int idOrder { get; set; }
        
        
        /// <summary>
        /// Порядковый номер внутри заказа. Входит в составной ключ
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime orderDateTime { get; set; }


        /// <summary>
        /// Клиент на которого записан заказ
        /// </summary>
        public  int clientId { get; set; }
        public Clients? clients { get; set; }


        /// <summary>
        /// Продукт в заказе
        /// </summary>
        public int productId { get; set; }
        public Products? product { get; set; }
    }
}
