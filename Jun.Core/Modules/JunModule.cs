using Autofac;
using Jun.Core.Dependency.LifeStyle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Autofac.Core;

namespace Jun.Core.Modules
{
    public class JunModule : Autofac.Module
    {

        public int Order { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //单例
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => typeof(ISingletonDependency).IsAssignableFrom(t))
            .AsImplementedInterfaces().AsSelf().SingleInstance();

            //瞬时
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => typeof(ITransientDependency).IsAssignableFrom(t))
            .AsImplementedInterfaces().AsSelf().InstancePerDependency();

            //Scope
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => typeof(IScopedDependency).IsAssignableFrom(t))
        .AsImplementedInterfaces().AsSelf().InstancePerRequest();

            base.Load(builder);
        }

    }
}
