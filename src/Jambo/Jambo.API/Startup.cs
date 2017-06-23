using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jambo.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using MediatR;

namespace Jambo.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
<<<<<<< HEAD
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
=======

            //services.AddSwaggerGen();
            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.DescribeAllEnumsAsStrings();
            //    options.SingleApiVersion(new Swashbuckle.Swagger.Model.Info()
            //    {
            //        Title = "Ordering HTTP API",
            //        Version = "v1",
            //        Description = "The Ordering Service HTTP API",
            //        TermsOfService = "Terms Of Service"
            //    });
            //});
>>>>>>> 099be64974c6460c11d9bb9b75fc9da35c27ce6e


            var container = new ContainerBuilder();
            container.Populate(services);

<<<<<<< HEAD
            //container.RegisterModule(new MediatorModule());
            //container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());
            //return services.BuildServiceProvider();
=======
            container.RegisterModule(new MediatorModule());
            //container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            IServiceProvider prov = new AutofacServiceProvider(container.Build());

            return prov;
>>>>>>> 099be64974c6460c11d9bb9b75fc9da35c27ce6e
        }


            //{
            //    // Add framework services.
            //    services.AddMvc();
            //    services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);


            //    var container = new ContainerBuilder();
            //    container.Populate(services);

            //    //container.RegisterModule(new MediatorModule());
            //    //container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            //    //return new AutofacServiceProvider(container.Build());
            //    return services.BuildServiceProvider();
            //}

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
