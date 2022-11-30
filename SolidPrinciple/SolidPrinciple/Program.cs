using Microsoft.Extensions.Configuration;
using SolidPrinciple;

    var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false);

    IConfiguration config = builder.Build();

    GameSettings ranges = new()
    {
        MinRange = int.Parse(config.GetSection("Ranges").GetSection("MinRange").Value),
        MaxRange = int.Parse(config.GetSection("Ranges").GetSection("MaxRange").Value),
        TryNumber = int.Parse(config.GetSection("TryNumber").Value)
    };





