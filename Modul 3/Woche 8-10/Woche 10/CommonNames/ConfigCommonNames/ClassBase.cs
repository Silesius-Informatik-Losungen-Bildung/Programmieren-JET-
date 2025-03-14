using Microsoft.Extensions.Configuration;

namespace ConfigCommonNames
{
    public static class ClassBase
    {
        public static IConfiguration Config { get; private set; }

        static ClassBase()
        {
            Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        }
    }
}
