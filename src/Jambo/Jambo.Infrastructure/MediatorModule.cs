using System.Collections.Generic;
using Autofac;
using MediatR;
using System.Reflection;
using Jambo.Application.Commands;
using System.Linq;
using Autofac.Core;

namespace Jambo.Infrastructure
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
        }
    }
}
