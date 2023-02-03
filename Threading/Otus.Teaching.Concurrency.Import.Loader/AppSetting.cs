using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.Loader
{
    public enum StartSetting
    {
        Procedure = 0,
        Process = 1
    }

    /// <summary>
    /// Класс обработки параметров в файле appsettings.json
    /// </summary>
    internal class AppSetting
    {
        /// <summary>
        /// Переключатель способа создания xml-файла
        /// </summary>
        public StartSetting startSetting { get; }
        
        /// <summary>
        /// exe-шник процесса
        /// </summary>
        public string processFile { get; }
        
        /// <summary>
        /// Кол-во обрабатываемых записей в потоке
        /// </summary>
        public int recordsPerThread { get; }


        public AppSetting()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            startSetting = (StartSetting)int.Parse(config.GetSection("StartInfo").Value);
            processFile = config.GetSection("ProcessFile").Value;
            recordsPerThread = int.Parse(config.GetSection("RecordsPerThread").Value);

        }
    }
}
