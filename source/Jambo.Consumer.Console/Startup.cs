using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MediatR;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using System.Threading;
using Jambo.Domain.ServiceBus;
using Jambo.Consumer.Application.DomainEventHandlers.Blogs;
using Autofac.Core;

namespace Jambo.Consumer.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IEnumerable<IModule> modules)
        {
            Configuration = configuration;
            _modules = modules;
        }

        private IEnumerable<IModule> _modules;
        public IConfiguration Configuration { get; }

        IServiceProvider serviceProvider;

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(BlogCreatedEventHandler).GetTypeInfo().Assembly);

            ContainerBuilder container = new ContainerBuilder();
            container.Populate(services);

            foreach (var module in _modules)
            {
                container.RegisterModule(module);
            }

            serviceProvider = new AutofacServiceProvider(container.Build());

            return serviceProvider;
        }

        public void Run()
        {
            IMediator mediator = serviceProvider.GetService<IMediator>();
            ISubscriber subscriber = serviceProvider.GetService<ISubscriber>();

            subscriber.Listen(mediator);

            while (true)
            {
                System.Console.WriteLine(DateTime.Now.ToString());
                Thread.Sleep(1000 * 60);
            }
        }
    }
}
