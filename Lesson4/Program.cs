using Lesson4;

    /// <summary>
    /// Строка соединения с БД
    /// </summary>
    var connectionString = "Data Source=91.219.6.251\\SQLEXPRESS; Initial Catalog=Otus; User Id=otuslogin; Password=1234";

    InitialDbSet initialDbSet = new (connectionString);

    // Создаем таблицы в БД, если они не существуют.
    await initialDbSet.CreateTables();


    // Предлагаем пользователю очистить таблицы
    Console.Write("Очистить таблицы (y/n)? ");
    if (Console.ReadLine()?.ToLower() == "y")
    {
       initialDbSet.ClearTables();
    }

    // Первичное наполнение таблиц (если они пустые).
    await initialDbSet.InitialFillTables();

    // Выводим в консоль все таблицы
    PrintTables printTables = new PrintTables(connectionString);
    printTables.PrintClients();
    Console.WriteLine(); Console.WriteLine();
    printTables.PrintProducts();
    Console.WriteLine(); Console.WriteLine();
    printTables.PrintOrders();
    Console.WriteLine(); Console.WriteLine();

    // Предлагаем пользователю внести новые записи в таблицы
    Console.Write("Хотите внести новые записи (y/n)? ");
    string? addQuestion = Console.ReadLine();

    while (addQuestion?.ToLower() == "y")
    {
        // Запрашиваем таблицу, куда пользователь хочет занести новую запись
        ControlTables controlTables = new ControlTables(connectionString);
        int tableNumber = controlTables.SelectTable();

        // Запускаем соответствующий метод занесения данных.
        switch (tableNumber)
        {
            case 1:
                controlTables.InsertClients();
                printTables.PrintClients();
                break;

            case 2:
                controlTables.InsertProduct();
                printTables.PrintProducts();
                break;

            case 3:
                controlTables.InsertOrder();
                printTables.PrintOrders();
                break;

            // Если пользователь ввел не число, либо число, не указывающие на таблицу -
            // ничего не делаем.
            default:
                break;
        }

        // Повторяем цикл, пока пользователь не прервет его.
        Console.WriteLine();
        Console.Write("Хотите внести еще записи (y/n)? ");
        addQuestion = Console.ReadLine();
    }



