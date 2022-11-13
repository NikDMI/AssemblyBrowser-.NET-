using System;
using System.Collections.Generic;
using AssemblyObserver.Bean.AssemblyParsing.Types;

namespace AssemblyObserver.Bean.AssemblyParsing.Namespace
{
    internal class NamespaceInfo: INamespaceInfo
    {
        public void AddTypeInfo(IType typeInfo)
        {
            _nestedTypes.Add(typeInfo);
        }


        public string GetNamespaceName()
        {
            return _namespaceName;
        }


        internal NamespaceInfo(string namespaceName)
        {
            _namespaceName = namespaceName;
        }


        private string _namespaceName;
        private List<IType> _nestedTypes;
    }
}
