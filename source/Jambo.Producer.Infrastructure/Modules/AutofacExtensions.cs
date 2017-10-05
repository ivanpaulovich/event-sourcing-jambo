using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jambo.Producer.Infrastructure.Modules;
using Jambo.Producer.UI;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jambo.Producer.Infrastructure.Modules
{
    public static class AutofacExtensions
    {
        public static IServiceCollection AddAutofac(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton<IServiceProviderFactory<ContainerBuilder>>(
                    o => new AutofacServiceProviderFactory(configuration)
                );
        }

        public static IWebHostBuilder UseAutofac(this IWebHostBuilder builder, IConfiguration configuration)
        {
            return builder.ConfigureServices(services => services.AddAutofac(configuration));
        }

        private class AutofacServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
        {
            private IConfiguration configuration;

            public AutofacServiceProviderFactory(IConfiguration configuration)
            {
                this.configuration = configuration;
            }

            public ContainerBuilder CreateBuilder(IServiceCollection services)
            {
                var containerBuilder = new ContainerBuilder();

                containerBuilder.Populate(services);

                containerBuilder.RegisterModule(new ApplicationModule(
                    configuration.GetSection("MongoDB").GetValue<string>("ConnectionString"),
                    configuration.GetSection("MongoDB").GetValue<string>("Database")));

                containerBuilder.RegisterModule(new BusModule(
                    configuration.GetSection("ServiceBus").GetValue<string>("ConnectionString"),
                    configuration.GetSection("ServiceBus").GetValue<string>("Topic")));

                return containerBuilder;
            }

            public IServiceProvider CreateServiceProvider(ContainerBuilder builder)
            {
                return new AutofacServiceProvider(builder.Build());
            }
        }
    }
}
