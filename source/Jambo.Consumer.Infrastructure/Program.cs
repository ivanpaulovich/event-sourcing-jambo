using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Jambo.Consumer.Application.DomainEventHandlers.Blogs;
using Jambo.Consumer.Infrastructure.Modules;
using Jambo.Consumer.UI;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;

namespace Jambo.Consumer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services.AddMediatR(typeof(BlogCreatedEventHandler).GetTypeInfo().Assembly);

            ICollection<IModule> modules = new Collection<IModule>();

            modules.Add(new ApplicationModule(
                configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                configuration.GetSection("MongoDB").GetValue<string>("Database")));

            modules.Add(new BusModule(
                configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                configuration.GetSection("ServiceBus").GetValue<string>("Topic")));

            Startup startup = new Startup(configuration, modules);
            startup.ConfigureServices(services);
            startup.Run();
        }
    }
}
