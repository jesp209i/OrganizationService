using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;

namespace OrganizationService.EventEmitter.Modules
{
    public class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly me = typeof(MediatRModule).Assembly;
            builder.RegisterMediatR(me);
        }
    }
}
