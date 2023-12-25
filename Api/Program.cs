using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults((webapi) =>
                {
                    webapi.UseStartup<Startup>();
                }).Build();

            host.Run();
        }
    }
}
