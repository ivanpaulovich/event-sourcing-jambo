using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Jambo.Domain.ServiceBus;
using Newtonsoft.Json;
using MediatR;
using Jambo.Application.Commands.Blogs;
using Autofac;
using Jambo.IoC;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Jambo.Web.Filters;

namespace Jambo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        IServiceProvider serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Filters.Add(typeof(CorrelationFilter));
            });

            services.AddMediatR(typeof(CreateBlogCommand).GetTypeInfo().Assembly);

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        private void ProcessDomainEventDelegate(string topic, string key, string value)
        {
            Type eventType = Type.GetType(key);
            DomainEvent domainEvent = (DomainEvent)JsonConvert.DeserializeObject(value, eventType);

            serviceProvider.GetService<IMediator>().Publish(domainEvent).Wait();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               });
        }
    }
}
