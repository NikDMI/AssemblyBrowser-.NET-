using System;
using System.Collections.Generic;
using AssemblyObserver.Bean.AssemblyParsing.Namespace;

namespace AssemblyObserver.Bean.AssemblyParsing.Assembly
{
    internal class AssemblyInfo : IAssemblyInfo
    {
        public void AddNamespaceInfo(INamespaceInfo namespaceInfo)
        {
            _namespacesInfo.Add(namespaceInfo);
        }

        public List<INamespaceInfo> GetAllNamespaces()
        {
            return _namespacesInfo;
        }


        internal AssemblyInfo()
        {
            _namespacesInfo = new List<INamespaceInfo>();
        }

        private List<INamespaceInfo> _namespacesInfo;
    }
}
