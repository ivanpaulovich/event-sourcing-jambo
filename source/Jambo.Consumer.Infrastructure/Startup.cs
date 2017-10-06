using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jambo.Consumer.Application.DomainEventHandlers.Blogs;
using Jambo.Consumer.Infrastructure.Modules;
using Jambo.Domain.ServiceBus;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Jambo.Consumer.Infrastructure
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
            services.AddMediatR(typeof(BlogCreatedEventHandler).GetTypeInfo().Assembly);

            ContainerBuilder container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule(
                Configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                Configuration.GetSection("MongoDB").GetValue<string>("Database")));

            container.RegisterModule(new BusModule(
                Configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                Configuration.GetSection("ServiceBus").GetValue<string>("Topic")));

            //container.RegisterModule(new MediatRModule());

            serviceProvider = new AutofacServiceProvider(container.Build());

            return serviceProvider;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async context =>
            {
                ISubscriber subscriber = serviceProvider.GetService<ISubscriber>();
                IMediator mediator = serviceProvider.GetService<IMediator>();

                subscriber.Listen(mediator);

                while (true)
                {
                    Console.WriteLine(DateTime.Now.ToString());
                    await Task.Delay(1000);
                }
            });
        }
    }
}
