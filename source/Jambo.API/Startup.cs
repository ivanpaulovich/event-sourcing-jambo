using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MediatR;
using Autofac;
using Jambo.API.IoC;
using Autofac.Extensions.DependencyInjection;
using Jambo.Application.Commands;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Jambo.Domain.Events;
using Newtonsoft.Json;

namespace Jambo.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        IServiceProvider serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddMediatR(typeof(CriarBlogCommand).GetTypeInfo().Assembly);

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Blogging HTTP API",
                    Version = "v1",
                    Description = "The Blogging Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
            });

            ContainerBuilder container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());

            container.RegisterModule(new ApplicationModule(
                Configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                Configuration.GetSection("MongoDB").GetValue<string>("Database")));

            container.RegisterModule(new ServiceBusModule(
                Configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                Configuration.GetSection("ServiceBus").GetValue<string>("Topic"),
                ProcessDomainEventDelegate));

            serviceProvider = new AutofacServiceProvider(container.Build());

            return serviceProvider;
        }

        private void ProcessDomainEventDelegate(string topic, string key, string value)
        {
            Type eventType = Type.GetType(key);
            DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(value, eventType);

            serviceProvider.GetService<IMediator>().Publish(domainEvent);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDeveloperExceptionPage();
            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               });
        }
    }
}
