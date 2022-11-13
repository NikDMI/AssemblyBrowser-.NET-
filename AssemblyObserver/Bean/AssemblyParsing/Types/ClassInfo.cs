using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AssemblyObserver.Bean.AssemblyParsing.Types
{
    internal class ClassInfo : IType
    {
        public string GetTypeDescription()
        {
            return _classType.Name;
        }

        internal ClassInfo(Type type)
        {
            _classType = type;
            _nestedTypes = new List<IType>();
            AddNestedFields();
            AddNestedProperties();
        }


        private void AddNestedFields()
        {
            //Public fields
            FieldInfo[] publicFields = _classType.GetFields(BindingFlags.Public);
            foreach (var field in publicFields)
            {
                _nestedTypes.Add(new SimpleType("public " + field.FieldType.Name + " " + field.Name));
            }
            //Private fields
            FieldInfo[] privateFields = _classType.GetFields(BindingFlags.NonPublic);
            foreach (var field in privateFields)
            {
                _nestedTypes.Add(new SimpleType("private " + field.FieldType.Name + " " + field.Name));
            }
        }


        private void AddNestedProperties()
        {
            PropertyInfo[] properties = _classType.GetProperties(BindingFlags.Public);
            foreach (var property in properties)
            {
                _nestedTypes.Add(new SimpleType("public " + GetPropertyDescription(property)));
            }
            properties = _classType.GetProperties(BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                _nestedTypes.Add(new SimpleType("private " + GetPropertyDescription(property)));
            }
        }


        private string GetPropertyDescription(PropertyInfo property)
        {
            string propertyDesc = property.PropertyType.Name + " " + property.Name + " {";
            if (property.CanWrite)
                propertyDesc += "set; ";
            if (property.CanRead)
                propertyDesc += "get; ";
            propertyDesc += " }";
            return propertyDesc;
        }


        private Type _classType;
        private List<IType> _nestedTypes;
    }
}
