using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace RequestMe
{
    public static class Program
    {
        private static string _url = "http://localhost:8000";
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
                _url = args[0];
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(_url);
    }
}