using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;

namespace Jambo.Consumer.Infrastructure
{
    class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureServices(services => services.AddAutofac())
                    .Build();
        }

        //static void Main(string[] args)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddEnvironmentVariables();

        //    IConfigurationRoot configuration = builder.Build();

        //    IServiceCollection services = new ServiceCollection();

        //    services.AddMediatR(typeof(BlogCreatedEventHandler).GetTypeInfo().Assembly);

        //    ICollection<IModule> modules = new Collection<IModule>();

        //    modules.Add(new ApplicationModule(
        //        configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
        //        configuration.GetSection("MongoDB").GetValue<string>("Database")));

        //    modules.Add(new BusModule(
        //        configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
        //        configuration.GetSection("ServiceBus").GetValue<string>("Topic")));

        //    Startup startup = new Startup(configuration, modules);
        //    startup.ConfigureServices(services);
        //    startup.Run();
        //}
    }
}
