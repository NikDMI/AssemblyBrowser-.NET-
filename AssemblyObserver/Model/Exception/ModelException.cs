using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyObserver.Model.Exception
{
    public class ModelException : System.Exception
    {
        public ModelException(string message): base(message)
        {}


        public ModelException(string message, System.Exception innerException) :base(message, innerException)
        {}


        public ModelException(System.Exception innerException): this("", innerException) { }
    }
}
