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
    internal class AppSetting
    {
        public StartSetting startSetting { get; }
        public string processFile { get; }

        public AppSetting()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            startSetting = (StartSetting)int.Parse(config.GetSection("StartInfo").Value);
            processFile = config.GetSection("ProcessFile").Value;

        }
    }
}
