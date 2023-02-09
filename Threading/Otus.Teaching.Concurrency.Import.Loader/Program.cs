using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.DataAccess.Parsers;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.DataGenerator.Generators;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;
using Otus.Teaching.Concurrency.Import.Loader.Loaders;

namespace Otus.Teaching.Concurrency.Import.Loader
{
    class Program
    {
        /// <summary>
        /// Папка с программой
        /// </summary>
        private static readonly string _dataFileDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// xml-файл
        /// </summary>
        private static string _dataFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customers.xml");

        /// <summary>
        /// Число записей по умолчанию
        /// </summary>
        private static int _dataCount = 1000;

        static void Main(string[] args)
        {

            var services = new ServiceCollection();

            services.AddScoped<ProcedureDataLoader>();
            services.AddScoped<ThreadDataLoader>();
            services.AddScoped<PoolDataLoader>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            
            var serviceProvider = services.BuildServiceProvider();
            
            var repo = serviceProvider.GetService<ICustomerRepository>();
            var procedureDataLoader = serviceProvider.GetService<ProcedureDataLoader>();
            var threadDataLoader = serviceProvider.GetService<ThreadDataLoader>();
            var poolDataLoader = serviceProvider.GetService<PoolDataLoader>();

            //Обрабатываем параметры коммандной строки
            if (args != null)
            {
                if (args.Length == 1)
                {
                    _dataFileName = Path.Combine(_dataFileDirectory, $"{args[0]}.xml");
                }
                if (args.Length > 1)
                {
                    _dataFileName = Path.Combine(_dataFileDirectory, $"{args[0]}.xml");
                    if (!int.TryParse(args[1], out _dataCount))
                    {
                        Console.WriteLine("Data must be integer");
                        return;
                    }
                }
            }

            Console.WriteLine($"Число записей: {_dataCount}");
            
            // Получаем настройки программы
            AppSetting app = new AppSetting();
            int threadCount = app.recordsPerThread;
            threadDataLoader.threadCount = threadCount;
            poolDataLoader.threadCount = threadCount;
            Console.WriteLine($"Количество обрабатываемых записей в потоке: {app.recordsPerThread}");
            Console.WriteLine();

            Stopwatch stopwatch = Stopwatch.StartNew();


            if (app.startSetting == StartSetting.Procedure) // Создание xml-файла вызовом процедуры
            {
                Console.WriteLine($"Loader started with process Id {Process.GetCurrentProcess().Id}...");
                GenerateCustomersDataFile();
            }
            
            if (app.startSetting == StartSetting.Process) // Создание xml-файла вызовом специального процесса
            {
                ProcessStartInfo StartInfo = new ProcessStartInfo(app.processFile);
                StartInfo.Arguments = $"\"{_dataFileName}\" {_dataCount}";
                StartInfo.UseShellExecute = true;
                var process = new Process();
                process.StartInfo = StartInfo;
                process.Start();

                Console.WriteLine($"Loader started with new process Id {process.Id}...");

                // Ждем завершенния процесса
                process.WaitForExit();
            }
            stopwatch.Stop();
            Console.WriteLine($"Создание xml-файла (мск): {(int)(stopwatch.ElapsedMilliseconds)}");
            Console.WriteLine();


            stopwatch.Restart();
            // Парсим xml- файл
            List<ThreadCustomer> customers = new XmlParser().Parse(_dataFileName);
            stopwatch.Stop();
            Console.WriteLine($"Парсинг xml-файла (мск): {(int)(stopwatch.ElapsedMilliseconds)}");
            Console.WriteLine();


            // Создаем таблицу в БД.

            repo.CreateDB();
            repo.Clear();
            Console.WriteLine($"База данных: {repo.GetDbName()}");
            Console.WriteLine();

            int cnts;
            int recCount = customers.Count;

            //Наполняем БД, используя метод класса ProcedureDataLoader
            stopwatch.Restart();
            Console.WriteLine("Working with PROCEDURE");

            procedureDataLoader.LoadData(customers);
            cnts = repo.Count();
            Console.WriteLine($"Число записей в таблице (проверка): {cnts}");
            stopwatch.Stop();
            Console.WriteLine($"Время(сек): {(int)(stopwatch.ElapsedMilliseconds / 1000)}");
            Console.WriteLine();

            // Очищаем таблицу
            repo.Clear();
            
            //Наполяем БД, создавая потоки
            stopwatch.Restart();
            Console.WriteLine("Working with THREADS");
            threadDataLoader.LoadData(customers);
            cnts = repo.Count();
            Console.WriteLine($"Число записей в таблице (проверка): {cnts}");
            stopwatch.Stop();
            Console.WriteLine($"Время(сек): {(int)(stopwatch.ElapsedMilliseconds / 1000)}");
            Console.WriteLine();
            
            // Очищаем таблицу
            repo.Clear();

            // Наполняем БД, используя очередь потоков
            stopwatch.Restart();
            Console.WriteLine("Working with THREADPOOL");
            poolDataLoader.LoadData(customers);
            cnts = repo.Count();
            Console.WriteLine($"Число записей в таблице (проверка): {cnts}");
            stopwatch.Stop();
            Console.WriteLine($"Время(сек): {(int)(stopwatch.ElapsedMilliseconds / 1000)}");
        }

        static void GenerateCustomersDataFile()
        {
            var xmlGenerator = new XmlGenerator(_dataFileName, 1000);
            xmlGenerator.Generate();
        }
    }
}