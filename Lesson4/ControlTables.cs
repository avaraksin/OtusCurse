namespace Lesson4
{
    /// <summary>
    /// Набор методов для добавления записей в таблицы
    /// </summary>
    public class ControlTables
    {
        /// <summary>
        /// Строка соединения с БД
        /// </summary>
        private readonly string _connectionString;


        public ControlTables(string connectionString)
        {
            _connectionString = connectionString;
        }


        /// <summary>
        /// Предлагает пользователю выбрать таблицу, в которую будем заносить записи.
        /// </summary>
        /// <returns>
        /// Возвращает номер таблицы (1 - 3).
        /// -1 - пользователь не сделал выбор
        /// </returns>
        public int SelectTable()
        {
            object selectedTable;

            Console.WriteLine("Укажите таблицу");
            Console.WriteLine("1. Клиенты");
            Console.WriteLine("2. Продукты");
            Console.WriteLine("3. Заказы");
            Console.Write("?");
            selectedTable = Console.ReadLine();

            int selected;
            if (int.TryParse((string)selectedTable, out selected))
            {
                if (selected > 0 && selected <= 3)
                {
                    return selected;
                }
            }

            return -1;
        }


        /// <summary>
        /// Занести запись в таблицу Clients (Клиенты)
        /// </summary>
        public void InsertClients()
        {
            Console.WriteLine("Имя клиента:");
            string? clientname = Console.ReadLine();

            using AppDBContext context = new AppDBContext(_connectionString);

            // Проверяем, что клиента с таким именем (без учета регистра) нет в таблице
            while (context.clients.Count(x => x.firstName.ToLower() == clientname.ToLower()) > 0)
            {
                Console.WriteLine("Такой клиент уже существует! Укажите другое имя!");
                clientname = Console.ReadLine();
            }

            // Вычисляем новый id
            int id;

            // Если в таблице нет записей - id = 1.
            if (context.clients.Count() == 0)
            {
                id = 1;
            }
            else // В противном случае вычисляем новый id = максимальный id + 1
            {
                id = context.clients.Select(x => x.id).Max() + 1;
            }

            // Если переданное имя не пустое - заносим его а таблицу
            if (string.IsNullOrEmpty(clientname) == false)
            {
                context.clients.Add(new Clients(id, clientname));
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Занести запись в таблицу Products (Продукты)
        /// </summary>
        public void InsertProduct()
        {
            Console.WriteLine("Укажите новый продукт:");
            string? productName = Console.ReadLine();

            using AppDBContext context = new AppDBContext(_connectionString);

            // Проверяем, что продукта с таким именем (без учета регистра) нет в таблице
            while (context.products.Count(x => x.productName.ToLower() == productName.ToLower()) > 0)
            {
                Console.WriteLine("Такой продукт уже существует! Укажите другое имя!");
                productName = Console.ReadLine();
            }

            int id;
            // Вычисляем новый id
            if (context.products.Count() == 0)
            {
                id = 1;
            }
            else
            {
                id = context.products.Select(x => x.id).Max() + 1;
            }

            // Если переданная строка с именем не пустая - сохраняем запись
            if (string.IsNullOrEmpty(productName) == false)
            {
                context.products.Add(new Products(id, productName));
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Занесение записи в таблицу Orders (Заказы).
        /// </summary>
        public void InsertOrder()
        {
            Console.WriteLine("Укажите номер заказа:");
            string? answer = Console.ReadLine();
            int orderNumber;

            // Проверяем, что введенный номер заказа - целое положительное число
            while (true)
            {
                if (!int.TryParse(answer, out orderNumber) || orderNumber <= 0)
                {
                    Console.WriteLine("Номер заказа - целое положительное число!");
                    answer = Console.ReadLine();
                    continue;
                }
                break;
            }

            PrintTables printTables = new PrintTables(_connectionString);

            using AppDBContext context = new AppDBContext(_connectionString);

            // Пытаемся получить id клиента.
            // Если заказ с таким номером уже существует - получаем номер клиента.
            int clientNumber = context.orders.Where(x => x.idOrder == orderNumber).Select(x => x.clientId).FirstOrDefault();
            bool flag;

            // Если введен новый новый номер заказа - запрашиваем клиента.
            if (clientNumber == 0)
            {
                Console.WriteLine("Укажите номер клиента:");
                printTables.PrintClients();
                
                do
                {
                    Console.Write("? ");
                    answer = Console.ReadLine();
                    flag = int.TryParse(answer, out clientNumber);
                }
                while (flag == false || context.clients.Where(x => x.id == clientNumber).Select(x => x.id).FirstOrDefault() == 0 );
            }
            

            // Запрашиваем id продукта
            int productNumber;
            Console.WriteLine("Укажите номер продукта:");
            printTables.PrintProducts();
           
            do
            {
                Console.Write("? ");
                answer = Console.ReadLine();
                flag = int.TryParse(answer, out productNumber);
            }
            while (flag == false || context.products.Where(x => x.id == productNumber).Select(x => x.id).FirstOrDefault() == 0 );

            int id;
            // Вычисляем новый id внутри заказа.
            if (context.orders.Count(x => x.idOrder == orderNumber) == 0)
            {
                id = 1;
            }
            else
            {
                id = context.orders.Where(x => x.idOrder == orderNumber).Select(x => x.id).Max() + 1;
            }

            // Формируем запись заказа и сохраняем ее.
            context.orders.Add(new Orders()
            {
                id = id,
                idOrder = orderNumber,
                clientId = clientNumber,
                productId = productNumber,
                orderDateTime = DateTime.Now
            });

            context.SaveChanges();
        }
    }
}
