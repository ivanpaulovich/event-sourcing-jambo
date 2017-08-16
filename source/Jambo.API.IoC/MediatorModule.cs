using Autofac;
using Autofac.Core;
using Jambo.Application.CommandHandlers;
using Jambo.Application.Commands;
using MediatR;
using System.Linq;
using System.Reflection;

namespace Jambo.API.IoC
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            //    .AsImplementedInterfaces();
        }
    }
}
