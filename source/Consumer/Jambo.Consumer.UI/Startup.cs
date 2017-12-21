namespace Jambo.Consumer.Infrastructure
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Jambo.Domain.ServiceBus;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;
    using System.Threading;
    using System.IO;
    using System.Linq;
    using System.Runtime.Loader;
    using Autofac.Configuration;
    using Jambo.Consumer.Application.DomainEventHandlers.Blogs;

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
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ConfigurationModule(Configuration));

            serviceProvider = new AutofacServiceProvider(builder.Build());

            return serviceProvider;
        }

        public void Run()
        {
            IMediator mediator = serviceProvider.GetService<IMediator>();
            ISubscriber subscriber = serviceProvider.GetService<ISubscriber>();

            subscriber.Listen(mediator);

            while (true)
            {
                Console.WriteLine($"{DateTime.Now.ToString()} Waiting for events..");
                Thread.Sleep(1000 * 60);
            }
        }
    }
}