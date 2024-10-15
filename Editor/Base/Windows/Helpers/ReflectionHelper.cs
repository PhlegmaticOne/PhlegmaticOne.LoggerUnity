using System;
using System.Collections.Generic;
using System.Linq;
using Assembly = System.Reflection.Assembly;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Helpers
{
    internal static class ReflectionHelper
    {
        public static Type ExtractTypeFromString(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }

            var splitFieldTypename = typeName.Split(' ');
            var assemblyName = splitFieldTypename[0];
            var subStringTypeName = splitFieldTypename[1];
            
            if (splitFieldTypename.Length > 2)
            {
                subStringTypeName = typeName.Substring(assemblyName.Length + 1);
            }

            var assembly = Assembly.Load(assemblyName);
            var targetType = assembly.GetType(subStringTypeName);
            return targetType;
        }
        
        public static IEnumerable<Type> GetImplementations<T>()
        {
            var assembly = Assembly.GetAssembly(typeof(T));

            return assembly.GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface);
        }

        public static bool IsFinalNonUnityType(Type type)
        {
            return type.IsAssignableFrom(type) && 
                   !type.IsAbstract && 
                   !type.IsInterface &&
                   !type.IsSubclassOf(typeof(UnityEngine.Object));
        }
    }
}