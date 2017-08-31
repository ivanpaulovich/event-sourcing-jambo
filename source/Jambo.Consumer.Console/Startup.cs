using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Jambo.Domain.ServiceBus;
using Newtonsoft.Json;
using MediatR;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Jambo.Application.Commands.Blogs;
using Autofac.Extensions.DependencyInjection;
using Jambo.Consumer.IoC;
using System.Threading;

namespace Jambo.Consumer.Console
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        IServiceProvider serviceProvider;

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateBlogCommand).GetTypeInfo().Assembly);

            ContainerBuilder container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule(
                Configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                Configuration.GetSection("MongoDB").GetValue<string>("Database")));

            container.RegisterModule(new BusModule(
                Configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                Configuration.GetSection("ServiceBus").GetValue<string>("Topic"),
                ProcessDomainEventDelegate));

            serviceProvider = new AutofacServiceProvider(container.Build());

            return serviceProvider;
        }

        private void ProcessDomainEventDelegate(string topic, string key, string value)
        {
            System.Console.WriteLine($"{topic} {key} {value}");

            Type eventType = Type.GetType(key);
            DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(value, eventType);

            serviceProvider.GetService<IMediator>().Publish(domainEvent).Wait();
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000 * 60);
                System.Console.WriteLine(DateTime.Now.ToString());
            }
        }
    }
}
