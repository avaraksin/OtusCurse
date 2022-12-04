using Microsoft.Extensions.Configuration;

namespace SolidPrinciple
{
    public class GetGameSettings
    {
        public static GameSettings Get()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            return new GameSettings()
            {
                MinRange = int.Parse(config.GetSection("Ranges").GetSection("MinRange").Value),
                MaxRange = int.Parse(config.GetSection("Ranges").GetSection("MaxRange").Value),
                AttempNumber = int.Parse(config.GetSection("TryNumber").Value)
            };
        }
    }
}
