using System;
using System.Collections.Generic;
using System.Text;
using AssemblyObserver.Bean.AssemblyParsing.Types;

namespace AssemblyObserver.Bean.AssemblyParsing.Namespace
{
    public interface INamespaceInfo
    {
        public void AddTypeInfo(IType typeInfo);

        public string GetNamespaceName();
    }
}
