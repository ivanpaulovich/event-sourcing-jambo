using Autofac;
using Autofac.Core;
using Autofac.Features.Variance;
using Jambo.Consumer.Application.DomainEventHandlers.Blogs;
using Jambo.Domain.Model.Blogs.Events;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Jambo.Consumer.Infrastructure.Modules
{
    public class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(BlogCreatedEventHandler).GetTypeInfo().Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IRequestHandler<>)))
                    .Select(i => new KeyedService("IRequestHandler", i)));

            builder
                .Register<SingleInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => { object o; return c.TryResolve(t, out o) ? o : null; };
                })
                .InstancePerLifetimeScope();

            builder
                .Register<MultiInstanceFactory>(ctx => {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();
        }
    }
}
