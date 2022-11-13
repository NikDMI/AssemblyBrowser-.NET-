using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyObserver.Model
{
    public static class ModelFactory
    {
        public static IModel GetModel()
        {
            return new Model();
        }
    }
}
