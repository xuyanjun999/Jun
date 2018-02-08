using Autofac;
using Jun.Core.Dependency.LifeStyle;
using Jun.Core.Modules;
using Jun.Data.Context;
using Jun.Data.Repository;
using Jun.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Data.Modules
{
    public class ServiceModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //单例
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => typeof(ISingletonDependency).IsAssignableFrom(t))
            .AsImplementedInterfaces().AsSelf().SingleInstance();

            //瞬时
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => typeof(ITransientDependency).IsAssignableFrom(t))
            .AsImplementedInterfaces().AsSelf().InstancePerDependency();

            //Scope
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => typeof(IScopedDependency).IsAssignableFrom(t))
        .AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
        }
    }
}
