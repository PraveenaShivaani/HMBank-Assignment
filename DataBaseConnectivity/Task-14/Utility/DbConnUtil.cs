using Microsoft.Extensions.Configuration;


namespace Task14.Utility
{
    internal static class DbConnUtil
    {
        private static IConfiguration configuration;

        //Create a Constructor
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return configuration.GetConnectionString("LocalConnectionString");
        }
    }
}

