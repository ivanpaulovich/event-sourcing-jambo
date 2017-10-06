using Autofac;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(BlogCreatedEventHandler).GetTypeInfo().Assembly);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationModule(
                Configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                Configuration.GetSection("MongoDB").GetValue<string>("Database")));

            builder.RegisterModule(new BusModule(
                Configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                Configuration.GetSection("ServiceBus").GetValue<string>("Topic")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ISubscriber subscriber, IMediator mediator)
        {
            app.Run(async context =>
            {
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
