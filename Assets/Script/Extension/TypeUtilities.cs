using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hawki
{
    public static class TypeUtilities
    {
        private static readonly Dictionary<Tuple<Type, bool>, List<Type>> DerivedTypesCache = new Dictionary<Tuple<Type, bool>, List<Type>>();

        public static IEnumerable<Type> FindAllDerivedTypes<T>(bool includeAbstract = false, Assembly assembly = null)
        {
            var key = Tuple.Create(typeof(T), includeAbstract);

            if (DerivedTypesCache.TryGetValue(key, out var derivedTypes))
            {
                return derivedTypes;
            }

            assembly = assembly ?? Assembly.GetAssembly(typeof(T));
            var allTypes = assembly.GetTypes();
            derivedTypes = allTypes
                .Where(t => typeof(T).IsAssignableFrom(t) && (includeAbstract || !t.IsAbstract))
                .ToList();

            DerivedTypesCache[key] = derivedTypes;

            return derivedTypes;
        }

        public static IEnumerable<Type> FindAllDerivedTypesInDomain<T>(bool includeAbstract = false)
        {
            var key = Tuple.Create(typeof(T), includeAbstract);

            if (DerivedTypesCache.TryGetValue(key, out var derivedTypes))
            {
                return derivedTypes;
            }

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.FullName.Contains("Editor"));
            derivedTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(T).IsAssignableFrom(t) && (includeAbstract || !t.IsAbstract))
                .ToList();

            DerivedTypesCache[key] = derivedTypes;

            return derivedTypes;
        }
    }
}
