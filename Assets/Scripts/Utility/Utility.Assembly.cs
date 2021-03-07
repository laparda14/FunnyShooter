using FunnyShooter.Core;
using System;
using System.Collections.Generic;
using SystemAssembly = System.Reflection.Assembly;

public static partial class Utility {
    /// <summary>
    /// 程序集工具类
    /// </summary>
    public static class Assembly {
        private static readonly SystemAssembly[] assemblies;
        private static readonly Type[] allTypes;
        private static readonly Dictionary<string, Type> cachedTypes = new Dictionary<string, Type>(StringComparer.Ordinal);

        static Assembly() {
            assemblies = AppDomain.CurrentDomain.GetAssemblies();
            allTypes = GetTypes();
        }

        public static SystemAssembly[] GetAssemblies() {
            return assemblies;
        }

        public static Type[] GetTypes() {
            List<Type> results = new List<Type>();
            foreach (SystemAssembly assembly in assemblies) {
                results.AddRange(assembly.GetTypes());
            }

            return results.ToArray();
        }

        public static void GetTypes(List<Type> results) {
            if (results == null) {
                throw new CustomException("Results is invalid.");
            }

            results.Clear();
            foreach (SystemAssembly assembly in assemblies) {
                results.AddRange(assembly.GetTypes());
            }
        }

        public static Type GetType(string typeName) {
            if (string.IsNullOrEmpty(typeName)) {
                throw new CustomException("Type name is invalid.");
            }

            if (cachedTypes.TryGetValue(typeName, out Type result)) {
                return result;
            }

            result = Type.GetType(typeName);
            if (result != null) {
                cachedTypes.Add(typeName, result);
                return result;
            }

            foreach (Type type in allTypes) {
                if (type.Name == typeName || type.FullName == typeName) {
                    cachedTypes.Add(typeName, type);
                    return type;
                }
            }

            return null;
        }
    }
}