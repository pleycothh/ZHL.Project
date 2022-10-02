using Autofac.Extensions.DependencyInjection;

namespace ZHL.GUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureWebHostDefaults(webBuilder =>
               {
                // electron.net
                // webBuilder.UseElectron(args);
#if DEBUG
                   webBuilder.UseEnvironment("Development");
#endif
                   // start razor pages
                   webBuilder.UseStartup<Startup>();
               });
        }
    }
}
