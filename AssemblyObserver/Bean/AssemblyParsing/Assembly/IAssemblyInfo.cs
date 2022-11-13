using System;
using System.Collections.Generic;
using System.Text;
using AssemblyObserver.Bean.AssemblyParsing.Namespace;

namespace AssemblyObserver.Bean.AssemblyParsing.Assembly
{
    public interface IAssemblyInfo
    {
        void AddNamespaceInfo(INamespaceInfo namespaceInfo);
    }
}
