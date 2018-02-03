using Autofac;
using Jun.Core.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Data.Modules
{
    public class DataModule:JunModule
    {
        public DataModule()
        {
            Order = 10;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
