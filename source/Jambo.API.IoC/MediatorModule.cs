using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Jambo.Application.Commands;
using Jambo.Application.DomainEventHandlers.BlogCriado;
using System.Linq;
using Autofac.Core;

namespace Jambo.API.IoC
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IAsyncRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CriarBlogCommand).GetTypeInfo().Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IAsyncRequestHandler<,>)))
                    .Select(i => new KeyedService("IAsyncRequestHandler", i)));

            // Register all the event classes (they implement IAsyncNotificationHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(BlogCriadoDomainEventHandler).GetTypeInfo().Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IAsyncNotificationHandler<>)))
                    .Select(i => new KeyedService("IAsyncNotificationHandler", i)))
                    .AsImplementedInterfaces();
        }
    }
}
