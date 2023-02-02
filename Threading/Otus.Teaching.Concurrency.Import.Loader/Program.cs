using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.DataAccess.Parsers;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.DataGenerator.Generators;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.Loader
{
    class Program
    {
        private static readonly string _dataFileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string _dataFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "customers.xml");
        private static int _dataCount = 1000;
        
        static void Main(string[] args)
        {
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

            AppSetting app = new AppSetting();

            if (app.startSetting == StartSetting.Procedure)
            {

                Console.WriteLine($"Loader started with process Id {Process.GetCurrentProcess().Id}...");
                GenerateCustomersDataFile();
                //p_Exited(null, null);
            }
            if (app.startSetting == StartSetting.Process)
            {

                ProcessStartInfo StartInfo = new ProcessStartInfo(app.processFile);
                StartInfo.Arguments = $"\"{_dataFileName}\" {_dataCount}";
                StartInfo.UseShellExecute = true;
                var process = new Process();
                process.StartInfo = StartInfo;
                process.Start();

                Console.WriteLine($"Loader started with process Id {process.Id}...");
                process.WaitForExit();
            }
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Customer> customers = new XmlParser().Parse(_dataFileName);
            var loader = new FakeDataLoader();

            loader.LoadData(customers);

            var context = SqliteContext.GetInstance();
            var cnts = context.customers.Count();

            Console.WriteLine($"Число записей: {cnts}");

            stopwatch.Stop();
            Console.WriteLine($"Время(сек): {(int)(stopwatch.ElapsedMilliseconds/1000)}");

        }

        static void GenerateCustomersDataFile()
        {
            var xmlGenerator = new XmlGenerator(_dataFileName, 1000);
            xmlGenerator.Generate();
        }

        static void p_Exited(object sender, EventArgs e)
        {
            
        }
    }
}