using Microsoft.EntityFrameworkCore;

namespace Lesson4
{
    /// <summary>
    /// Набор методов для вывода таблиц на экран (в  консоль)
    /// </summary>
    public class PrintTables
    {
        /// <summary>
        /// Строка соединения с БД
        /// </summary>
        private readonly string _connectionString;



        public PrintTables(string connectionString)
        {
            _connectionString = connectionString;
        }



        /// <summary>
        /// Вывод в в консоль таблицы Clients (Клиенты)
        /// </summary>
        public void PrintClients()
        {
            using (AppDBContext context = new AppDBContext(_connectionString))
            {
                // Если таблица пустая - выводим соответствующее сообщение.
                if (context.clients.Count() == 0)
                {
                    Console.WriteLine("Таблица Clients пустая!");
                    return;
                }

                Console.WriteLine("Clients");
                Console.WriteLine("№№\tid\tFirstName");
                var result = context.clients.ToList();

                for (var i = 0; i < result.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}\t{result[i].id}\t{result[i].firstName}");
                }
            }
        }



        /// <summary>
        /// Вывод в в консоль таблицы Products (Продукты)
        /// </summary>
        public void PrintProducts()
        {
            using (AppDBContext context = new AppDBContext(_connectionString))
            {
                if (context.products.Count() == 0)
                {
                    Console.WriteLine("Таблица Products пустая!");
                    return;
                }

                Console.WriteLine("Products");
                Console.WriteLine("№№\tid\tProductName");
                var result = context.products.ToList();

                for (var i = 0; i < result.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}\t{result[i].id}\t{result[i].productName}");
                }
            }
        }



        /// <summary>
        /// Вывод в консоль таблицы Orders (Заказы)
        /// </summary>
        public void PrintOrders()
        {
            using (AppDBContext context = new AppDBContext(_connectionString))
            {
                if (context.orders.Count() == 0)
                {
                    Console.WriteLine("Таблица Orders пустая!");
                    return;
                }

                var result = context.orders.Include(x => x.product).Include(x => x.clients).ToList();

                Console.WriteLine("Orders");
                Console.WriteLine($"№№\tId заказа\tКлиент\t\tID в заказе\tПродукт\t\tДата заказа");
                for (var i = 0; i < result.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}\t{result[i].idOrder}\t\t{result[i].clients.firstName}\t\t{result[i].id}\t\t{result[i].product.productName}\t\t{result[i].orderDateTime.ToString("dd.MM.yyyy")}");
                }

            }

        }
    }
}
