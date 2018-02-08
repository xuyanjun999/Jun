
using Jun.Core.Dependency;
using Jun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Service
{
    public class ServiceBase
    {
        public IRepositoryBase Repository { get; set; }

        public ServiceBase()
        {
            Repository = IocManager.Instance.Resolve<IRepositoryBase>();
        }
    }
}
