using Jun.Core.Dependency.LifeStyle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Core.Reflection
{
    public interface ITypeFinder: ISingletonDependency
    {
        Type[] Find(Func<Type, bool> predicate);

        Type[] FindAll();
    }
}
