using Microsoft.Extensions.Configuration;

namespace SolidPrinciple
{
    /// <summary>
    /// Настроки игры
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// Нижний предел
        /// </summary>
        public int MinRange { get; set; }
        
        
        /// <summary>
        /// Верхний предел
        /// </summary>
        public int MaxRange { get; set; }
        
        
        /// <summary>
        /// Число попыток
        /// </summary>
        public int AttempNumber { get; set; }

        public GameSettings()
        {
            // Получаем настройки из json-файла
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            MinRange        = int.Parse(config.GetSection("Ranges").GetSection("MinRange").Value);
            MaxRange        = int.Parse(config.GetSection("Ranges").GetSection("MaxRange").Value);
            AttempNumber    = int.Parse(config.GetSection("TryNumber").Value);
        }
    }
}
