﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using jvm4csharp.ArrayUtils;
using jvm4csharp.java.lang;

namespace jvm4csharp.JniApiWrappers
{
    internal sealed class ProxyRegistry
    {
        public static ProxyRegistry Current { get; private set; }

        private readonly IDictionary<string, Type> _classNameToProxyType = new Dictionary<string, Type>();
        private readonly IDictionary<Type, string> _proxyTypeToClassNameMap = new Dictionary<Type, string>();

        private ProxyRegistry(IEnumerable<Type> proxyTypes)
        {
            Debug.Assert(proxyTypes != null);

            var defaultProxyTypes = GetDefaultProxyTypes();
            foreach (var item in defaultProxyTypes)
                RegisterProxy(item.Item1, item.Item2);

            foreach (var type in proxyTypes)
                RegisterProxy(type, null);
        }

        public static void Configure(IEnumerable<Type> proxyTypes)
        {
            Current = new ProxyRegistry(proxyTypes);
        }

        //TODO: handle arrays
        public string GetClassName(Type javaProxyType)
        {
            Debug.Assert(javaProxyType != null);

            if (javaProxyType.IsGenericType)
                javaProxyType = javaProxyType.GetGenericTypeDefinition();

            string className;
            if (!_proxyTypeToClassNameMap.TryGetValue(javaProxyType, out className))
                throw new ArgumentException($"Proxy type '{javaProxyType}' not recognized.");

            return className;
        }

        public bool TryGetProxyType(string internalClassName, out Type proxyType)
        {
            Debug.Assert(internalClassName != null);
            return _classNameToProxyType.TryGetValue(internalClassName, out proxyType);
        }

        private void RegisterProxy(Type proxyType, JavaProxyAttribute javaProxyAttribute)
        {
            Debug.Assert(proxyType != null);

            if (javaProxyAttribute == null)
            {
                javaProxyAttribute = GetJavaProxyAttribute(proxyType);
                if (javaProxyAttribute == null)
                    throw new ArgumentException($"Invalid proxy definition '{proxyType}'. Could not find 'JavaProxyAttribute'.");
            }

            var internalClassName = javaProxyAttribute.ClassName;
            if (_classNameToProxyType.ContainsKey(internalClassName))
                throw new ArgumentException($"Duplicate proxy type '{proxyType}' detected. Java class name '{internalClassName}'.");

            if (string.IsNullOrWhiteSpace(internalClassName))
                throw new ArgumentException($"Invalid proxy definition '{proxyType}'. Missing 'JavaProxyAttribute.ClassName' property.");

            if (!proxyType.IsInterface)
            {
                if (!typeof(java.lang.Object).IsAssignableFrom(proxyType) && !typeof(Throwable).IsAssignableFrom(proxyType))
                    throw new ArgumentException($"Invalid proxy definition '{proxyType}'. Proxy types must inherit from 'java.lang.Object' or 'java.lang.Throwable'.");
            }

            ValidateGenericTypeParameters(proxyType);

            _classNameToProxyType[internalClassName] = proxyType;
            _proxyTypeToClassNameMap[proxyType] = internalClassName;
        }

        private static void ValidateGenericTypeParameters(Type type)
        {
            if (!type.IsGenericTypeDefinition)
                return;

            var genericTypeDefinition = type.GetGenericTypeDefinition().GetTypeInfo();
            var genericTypeParameters = genericTypeDefinition.GenericTypeParameters;

            foreach (var typeParameter in genericTypeParameters)
            {
                var constraints = typeParameter.GetGenericParameterConstraints();

                if (constraints.Length == 0)
                    throw new ArgumentException(""); //TODO

                foreach (var constraint in constraints)
                    if (!(typeof(IJavaObject).IsAssignableFrom(constraint)))
                        throw new ArgumentException(""); //TODO
            }
        }

        private static JavaProxyAttribute GetJavaProxyAttribute(Type type)
        {
            return (JavaProxyAttribute)type.GetCustomAttributes(typeof(JavaProxyAttribute), false).FirstOrDefault();
        }

        private static IEnumerable<Tuple<Type, JavaProxyAttribute>> GetDefaultProxyTypes()
        {
            var assembly = typeof(ProxyRegistry).Assembly;
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var attr = GetJavaProxyAttribute(type);
                if (attr != null)
                    yield return new Tuple<Type, JavaProxyAttribute>(type, attr);
            }
        }
    }
}
