using System;
using System.Collections.Generic;
using AssemblyObserver.Bean.AssemblyParsing.Assembly;

namespace AssemblyObserver.View
{
    public interface IView
    {
        public void ShowAssemblyInfo(IAssemblyInfo assemblyInfo);
    }
}
