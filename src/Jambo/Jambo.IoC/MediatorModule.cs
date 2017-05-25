using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MediatR;

namespace Jambo.IoC
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            // Register all the Command classes (they implement IAsyncRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(CreateOrderCommand).GetTypeInfo().Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>)))
                    .Select(i => new KeyedService("IAsyncRequestHandler", i)));

            // Register all the event classes (they implement IAsyncNotificationHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler).GetTypeInfo().Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IAsyncNotificationHandler<>)))
                    .Select(i => new KeyedService("IAsyncNotificationHandler", i)))
                    .AsImplementedInterfaces();


            builder
                .RegisterAssemblyTypes(typeof(CreateOrderCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();


            builder.Register<SingleInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();

                return t => componentContext.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();

                return t => (IEnumerable<object>)componentContext.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });



            builder.RegisterGenericDecorator(typeof(LogDecorator<,>),
                    typeof(IAsyncRequestHandler<,>),
                    "IAsyncRequestHandler")
                    .Keyed("handlerDecorator", typeof(IAsyncRequestHandler<,>));

            builder.RegisterGenericDecorator(typeof(ValidatorDecorator<,>),
                    typeof(IAsyncRequestHandler<,>),
                    fromKey: "handlerDecorator");
        }
    }
}
