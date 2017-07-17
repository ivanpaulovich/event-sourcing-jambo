using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Jambo.Infrastructure.Repositories;
using Jambo.Domain.AggregatesModel.BlogAggregate;

namespace Jambo.API.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogWriteOnlyRepository>()
                .As<IBlogWriteOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
