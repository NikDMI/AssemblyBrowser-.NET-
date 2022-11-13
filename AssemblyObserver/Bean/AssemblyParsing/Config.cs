using System;
using System.Collections.Generic;
using System.Text;
using AssemblyObserver.Bean.AssemblyParsing.Assembly;
using AssemblyObserver.Bean.AssemblyParsing.Namespace;
using AssemblyObserver.Bean.AssemblyParsing.Types;

namespace AssemblyObserver.Bean.AssemblyParsing
{
    internal static class Config
    {
        //Parse nested type
        internal static IType GetTypeInfo(Type type)
        {
            if (type.IsClass || type.IsInterface)
            {
                return new ClassInfo(type);
            }
            return null;
        }
    }
}
