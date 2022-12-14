using System;
using System.Collections.Generic;
using AssemblyObserver.Bean.AssemblyParsing.Assembly;
using AssemblyObserver.Bean.AssemblyParsing.Namespace;
using AssemblyObserver.Bean.AssemblyParsing.Types;
using AssemblyObserver.Bean.AssemblyParsing;
using System.Reflection;
using AssemblyObserver.Model.Exception;

namespace AssemblyObserver.Model
{
    internal sealed class Model : IModel
    {
        public IAssemblyInfo GetAssemblyInfo(string assemblyFileName)
        {
            Assembly loadedAssembly;
            try
            {
                loadedAssembly = Assembly.LoadFile(assemblyFileName);
            }
            catch (System.Exception e)
            {
                throw new ModelException("Assembly load error", e);
            }
            var namespacesInfo = GetAssemblyNamespaces(loadedAssembly);
            AssemblyInfo assemblyInfo = new AssemblyInfo();
            foreach (var nsInfo in namespacesInfo)
            {
                assemblyInfo.AddNamespaceInfo(nsInfo);
            }
            return assemblyInfo;
        }


        private List<INamespaceInfo> GetAssemblyNamespaces(Assembly assembly)
        {
            Dictionary<string, INamespaceInfo> assemblyNamespaces = new Dictionary<string, INamespaceInfo>();
            INamespaceInfo lastNamespace = null;
            Type[] assemblyTypes = assembly.GetTypes();
            foreach (var type in assemblyTypes)
            {
                //Choose current namespace
                if (lastNamespace == null || type.Namespace != lastNamespace.GetNamespaceName())
                {
                    if (!assemblyNamespaces.TryGetValue(type.Namespace, out lastNamespace))
                    {
                        lastNamespace = new NamespaceInfo(type.Namespace);
                        assemblyNamespaces.Add(type.Namespace, lastNamespace);
                    }
                }
                //Add nested type to namespace
                IType nestedType = Config.GetTypeInfo(type);
                lastNamespace.AddTypeInfo(nestedType);
            }
            List<INamespaceInfo> namespaceList = new List<INamespaceInfo>();
            foreach (var namespaces in assemblyNamespaces)
            {
                namespaceList.Add(namespaces.Value);
            }
            return namespaceList;
        }

    }
}
