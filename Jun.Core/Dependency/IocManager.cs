using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Core.Dependency
{
    public class IocManager
    {

        public static IocManager Instance = null;

        public IContainer Container = null;

        static IocManager()
        {
            Instance = new IocManager();
        }

        private IocManager()
        {

        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">Type of resolved service</typeparam>
        /// <returns>Resolved service</returns>
        public T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <param name="type">Type of resolved service</param>
        /// <returns>Resolved service</returns>
        public object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">Type of resolved services</typeparam>
        /// <returns>Collection of resolved services</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable < T > )Container.Resolve<T>();
        }


    }
}
