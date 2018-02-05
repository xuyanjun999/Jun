using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Jun.Core.Reflection
{
    public class TypeFinder:ITypeFinder
    {

        private readonly object _syncObj = new object();
        private Type[] _types;

        public Type[] Find(Type assignTypeFrom)
        {
            Func<Type, bool> predicate = new Func<Type, bool>(t=>assignTypeFrom.IsAssignableFrom(t) || (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, assignTypeFrom)));
            return GetAllTypes().Where(predicate).ToArray();
        }

        public Type[] FindAll()
        {
            return GetAllTypes().ToArray();
        }

        private Type[] GetAllTypes()
        {
            if (_types == null)
            {
                lock (_syncObj)
                {
                    if (_types == null)
                    {
                        _types = CreateTypeList().ToArray();
                    }
                }
            }

            return _types;
        }

        private List<Type> CreateTypeList()
        {
            var allTypes = new List<Type>();

            var assemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load);
        //.SelectMany(x => x.DefinedTypes);//  _assemblyFinder.GetAllAssemblies().Distinct();

            foreach (var assembly in assemblies)
            {
                try
                {
                    Type[] typesInThisAssembly;

                    try
                    {
                        typesInThisAssembly = assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        typesInThisAssembly = ex.Types;
                    }

                    allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
                }
                catch (Exception ex)
                {
                    //Logger.Warn(ex.ToString(), ex);
                }
            }

            return allTypes;
        }

        /// <summary>
        /// Does type implement generic?
        /// </summary>
        /// <param name="type"></param>
        /// <param name="openGeneric"></param>
        /// <returns></returns>
        protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
