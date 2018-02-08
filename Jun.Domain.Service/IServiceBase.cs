using Jun.Core.Dependency;
using Jun.Core.Dependency.LifeStyle;
using Jun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Domain.Service
{
    public interface IServiceBase: IScopedDependency
    {
         IRepositoryBase Repository { get; set; }

    }
}
