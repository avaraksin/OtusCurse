﻿using Otus.Teaching.Concurrency.Import.Handler.Data;
using System;
using System.IO;
using System.Threading;
using XmlDataGenerator = Otus.Teaching.Concurrency.Import.DataGenerator.Generators.XmlGenerator;

namespace Otus.Teaching.Concurrency.Import.XmlGenerator
{
    class Program
    {
        private static readonly string _dataFileDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string _dataFileName; 
        private static int _dataCount = 100; 
        
        static void Main(string[] args)
        {
            if (!TryValidateAndParseArgs(args))
                return;

            StartSetting setting = new AppSetting().startSetting;
            Console.WriteLine($"Generating xml data by {setting}");

            IDataGenerator generator;

            File.Delete(_dataFileName);

            if (setting == StartSetting.Procedure) // Создание xml-файла в методе
            {
                generator = GeneratorFactory.GetGenerator(_dataFileName, _dataCount);
                generator.Generate();
            }
            if (setting == StartSetting.Thread) // Создание xml-файла в новом потоке
            {
                Thread thread = new Thread( () =>
                {
                    generator = GeneratorFactory.GetGenerator(_dataFileName, _dataCount);
                    generator.Generate();
                    Console.WriteLine("Quit the thread");
                });
                thread.Start();
                thread.Join();
            }

            Console.WriteLine($"Generated xml data in {_dataFileName} by {setting}");
        }

        private static bool TryValidateAndParseArgs(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var fileName = args[0];
                if (fileName.Contains("\\"))
                {
                    _dataFileName = fileName;
                }
                else
                {
                    _dataFileName = Path.Combine(_dataFileDirectory, $"{fileName}.xml");
                }
            }
            else
            {
                Console.WriteLine("Data file name without extension is required");
                return false;
            }
            
            if (args.Length > 1)
            {
                if (!int.TryParse(args[1], out _dataCount))
                {
                    Console.WriteLine("Data must be integer");
                    return false;
                }
            }

            return true;
        }
    }
}