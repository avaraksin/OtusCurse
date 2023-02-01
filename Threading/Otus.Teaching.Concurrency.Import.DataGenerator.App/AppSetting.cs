using Microsoft.Extensions.Configuration;
using System.IO;

namespace Otus.Teaching.Concurrency.Import.XmlGenerator
{
    public enum StartSetting
    {
        Procedure = 0,
        Thread = 1
    }
    internal class AppSetting
    {
        public StartSetting startSetting {get;set;}

        public AppSetting()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            startSetting = (StartSetting)int.Parse(config.GetSection("StartSetting").Value);
            
        }
    }
}
