using System;
using System.Collections.Generic;
using System.Text;
using AssemblyObserver.Bean.AssemblyParsing.Assembly;

namespace AssemblyObserver.Model
{
    public interface IModel
    {
        /***
         * Parse assembly
         */
        IAssemblyInfo GetAssemblyInfo(string assemblyFileName);
    }
}
