using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyObserver.Bean.AssemblyParsing.Types
{
    //Represents methods, fields, properties
    internal class SimpleType : IType
    {
        public string GetTypeDescription()
        {
            return _typeDescription;
        }


        public List<IType> GetNestedTypes()
        {
            return null;
        }


        internal SimpleType(string typeDescription)
        {
            _typeDescription = typeDescription;
        }

        private string _typeDescription = "";
    }
}
